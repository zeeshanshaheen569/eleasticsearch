using ElasticApplication.Common.Interfaces;
using ElasticApplication.Common.Interfaces.ExternalApiInterFace;
using ElasticApplication.Common.Models;
using ElasticDomain.Entiities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ElasticInfrastrucre.Index.Create
{
    class CreateIndex : ICreateIndex
    {

        private readonly IReader _Reader;
        private readonly IFormater _Formater;
        private readonly IWriter _Writer;
        private readonly ICreateIndexApi _ICreateIndexApi;
        private readonly IMappings _Mappings;
        private readonly AppIdentitySettings AppIdentitySettings;
        public CreateIndex(IReader reader,IFormater formater,IWriter writer, ICreateIndexApi createIndexApi,
            IMappings mappings,
            IOptionsMonitor<AppIdentitySettings> options)
        {
            _Reader = reader;
            _Formater = formater;
            _Writer = writer;
            _ICreateIndexApi = createIndexApi;
            _Mappings = mappings;
            AppIdentitySettings =  options.CurrentValue; 

        }

        public string CreateMultipleIndex()
        {

            var isManagementIndexCreated = CreateManagementIndex(AppIdentitySettings.IndexNames.ManagmentIndexName);
            var isPropertyIndexCreateed=CreatePropertyIndex(AppIdentitySettings.IndexNames.PropertyIndexName);

            return isManagementIndexCreated && isPropertyIndexCreateed ? "Index has been Created " : "Index Crateion Failed";
        }
        //this method will read,format,write and then create the management index
        public bool CreateManagementIndex(string IndexName)
        {
            var managementData = _Reader.read<Managment>(AppIdentitySettings.Paths.PathToMgmt);
            var mangementFormated = _Formater.formatMangment(managementData, IndexName);
            var managmentFile = Path.Combine(Directory.GetCurrentDirectory(), AppIdentitySettings.Paths.PathToBulkProperty + IndexName + ".json");
            var isManagmentWriteSuccess = _Writer.WriteManagemntData(mangementFormated, managmentFile);
            if (isManagmentWriteSuccess)
            {
                var managmentMappings = _Mappings.getManagmentIndexMappings();
                var isManagmentMappingCreated = _ICreateIndexApi.createIndexMapping(AppIdentitySettings.Urls.BaseUrl+IndexName, managmentMappings);
                if (isManagmentMappingCreated)
                {
                   return _ICreateIndexApi.createIndexByBulkData(managmentFile, AppIdentitySettings.Urls.BaseUrl + "_bulk");
                }

               
            }
            return false;
        }


        //this method will read,format,write and then create the management index
        public bool CreatePropertyIndex(string IndexName)
        {
            var propertyData = _Reader.read<Property>(AppIdentitySettings.Paths.PathToProperty);
            var propertyFormated = _Formater.formatProperty(propertyData, IndexName);
            var propertyFile = Path.Combine(Directory.GetCurrentDirectory(), AppIdentitySettings.Paths.PathToBulkProperty + IndexName + ".json");
            var ispropertyWriteSuccess = _Writer.WritePropertyData(propertyFormated, propertyFile);
            if (ispropertyWriteSuccess)
            {
                var propertyMappings = _Mappings.getPropertyIndexMappings();
                var ispropertyMappingCreated = _ICreateIndexApi.createIndexMapping(AppIdentitySettings.Urls.BaseUrl + IndexName, propertyMappings);
                if (ispropertyMappingCreated)
                {
                    return _ICreateIndexApi.createIndexByBulkData(propertyFile, AppIdentitySettings.Urls.BaseUrl + "_bulk");
                }

            }
            return false;
        }
    }
}
