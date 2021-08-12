using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElasticDomain.Entiities
{
    public class Managment
    {
        public ManagmentInfo Mgmt { get; set; }
    }

    public class ManagmentInfo
    {
        [JsonProperty("mgmtID")]
        public int MgmtID { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("market")]
        public string Market { get; set; }
        [JsonProperty("state")]
        public string State { get; set; }

    }

    
}
