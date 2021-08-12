using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElasticApplication.Common.Interfaces;
using ElasticApplication.Common.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ElasticApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly ISearchIndex _SearchIndex;
        public SearchController(ISearchIndex searchIndex)
        {
            _SearchIndex = searchIndex;
        }

        // GET: api/Search
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // POST: api/Search
        [HttpPost]
        public ActionResult Search(SearchRequest searchRequest)
        {


            return Ok(_SearchIndex.searchEleastic(searchRequest));
        }

        // PUT: api/Search/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
