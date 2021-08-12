using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElasticDomain.Entiities
{

    public class Property
    {
        public PropertyInfo property { get; set; }
    }
    public class PropertyInfo
    {
        [JsonProperty("propertyID")]
        public int PropertyID { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("formerName")]
        public string FormerName { get; set; }
        [JsonProperty("streetAddress")]
        public string StreetAddress { get; set; }
        [JsonProperty("city")]
        public string City { get; set; }
        [JsonProperty("market")]
        public string Market { get; set; }
        [JsonProperty("state")]
        public string State { get; set; }
        [JsonProperty("lat")]
        public double Lat { get; set; }
        [JsonProperty("lng")]
        public double Lng { get; set; }
    }
}

