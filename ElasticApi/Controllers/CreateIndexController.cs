using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElasticApplication.Common.Interfaces;
using ElasticApplication.Common.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ElasticApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreateIndexController : ControllerBase
    {
        private readonly ICreateIndex _CreateIndex;
        public CreateIndexController(ICreateIndex createIndex)
        {
            _CreateIndex = createIndex;
        }

        // GET: api/CreateIndex
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        

        // POST: api/CreateIndex
        // this method will be hit when we want to create index
        [HttpPost]
        public ActionResult Post()
        {
           var result =  _CreateIndex.CreateMultipleIndex();
            return Ok(
                        result 
            );
        }

        // PUT: api/CreateIndex/5
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
