using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ElasticApplication.Common.Models
{
    public class SearchRequest
    {


        [Required(ErrorMessage = "Please Enter Search String")]
        [StringLength(25)]
        public string Search { get; set; }

        public List<string> Market { get; set; }

        [Range(10, 100, ErrorMessage = "Minimum Limit is 10 and Maximum limit is Hundered")]
        public int Limit { get; set; } = 25;

        [Range(0, 100, ErrorMessage = "Minimum Limit is 0 and  Maximum limit is Hundered")]
        public int From { get; set; } = 0;

    }
   


}
