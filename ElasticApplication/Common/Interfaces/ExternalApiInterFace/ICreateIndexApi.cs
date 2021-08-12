using System;
using System.Collections.Generic;
using System.Text;

namespace ElasticApplication.Common.Interfaces.ExternalApiInterFace
{
    public interface ICreateIndexApi
    {
        //uploads index data bulk
        bool createIndexByBulkData(string filePath, string url);
        //uploads index mappings 
        bool createIndexMapping(string url, string mappings);
    }
}
