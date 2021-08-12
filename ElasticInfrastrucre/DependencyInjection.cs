using ElasticApplication.Common.Interfaces;
using ElasticApplication.Common.Interfaces.ExternalApiInterFace;
using ElasticApplication.Common.Models;
using ElasticInfrastrucre.ExternalApi;
using ElasticInfrastrucre.Format;
using ElasticInfrastrucre.Index.Create;
using ElasticInfrastrucre.Index.Search;
using ElasticInfrastrucre.Mapper;
using ElasticInfrastrucre.Read;
using ElasticInfrastrucre.Write;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElasticInfrastrucre
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddElasticInfrastructure(this IServiceCollection services)
        {
            services.AddSingleton<IReader, Reader>();
            services.AddSingleton<IFormater, Formater>();
            services.AddSingleton<ISearchIndex, SearchIndex>();
            services.AddSingleton<IWriter, Writer>();
            services.AddSingleton<IMappings, Mappings>();
            services.AddSingleton<ICreateIndex, CreateIndex>();
            services.AddSingleton<ISearchIndexApi, SearchIndexApi>();
            services.AddSingleton<ICreateIndexApi, CreateIndexApi>();


            services.AddHttpClient();

            return services;
        }

       
    }
}
