using System;
using System.Collections.Generic;
using System.Text;

namespace ElasticApplication.Common.Models
{
    public class AppIdentitySettings
    {
        public Paths Paths { get; set; }
        public Urls Urls { get; set; }

        public IndexNames IndexNames { get; set; }
    }
    public class Paths
    {
        public string PathToMgmt { get; set; }
        public string PathToProperty { get; set; }

        public string PathToBulkProperty { get; set; }
        public string PathToBulkMgmt { get; set; }


    }

    public class Urls
    {
        public string BaseUrl { get; set; }
        
    }

    public class IndexNames
    {
        public string ManagmentIndexName { get; set; }
        public string PropertyIndexName { get; set; }

    }
}
