using ElasticDomain.Entiities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace ElasticApplication.Common.Models
{
    public class FormatedManagement
    {
        public ManagementIndex index { get; set; }


        public ManagmentInfo Fields { get; set; }

    }

    public class ManagementIndex
    {
        [JsonProperty("_type")]
        public string Type { get; set; } = "_doc";

        [JsonProperty("_index")]
        public string IndexName { get; set; } 
        [JsonProperty("_id")]
        public int Id { get; set; }

    }

   

}
