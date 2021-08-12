using ElasticApplication.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ElasticInfrastrucre.Read
{
    class Reader : IReader
    {
        public List<T> read<T>(string path)
        {

            try
            {
                var folderDetails = Path.Combine(Directory.GetCurrentDirectory(), $"{path}");
                string result;
                using (StreamReader streamReader = new StreamReader(folderDetails))
                {
                    result = streamReader.ReadToEnd();
                }
                var jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject<List<T>>(result);
                return jsonObj.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
