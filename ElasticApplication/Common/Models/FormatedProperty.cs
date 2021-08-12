using System;
using System.Collections.Generic;
using System.Text;
using ElasticDomain.Entiities;
using Newtonsoft.Json;


namespace ElasticApplication.Common.Models
{
    public class FormatedProperty
    {
        public PropertyIndex index { get; set; }
        public PropertyInfo Fields { get; set; }
    }

    public class PropertyIndex
    {

        [JsonProperty("_type")]
        public string Type { get; set; } = "_doc";

        [JsonProperty("_index")]
        public string IndexName { get; set; } 
        [JsonProperty("_id")]
        public int Id { get; set; }


    }

   
}
