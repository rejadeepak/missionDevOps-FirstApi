﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VSCodeEventBus.Controllers.Misc;

namespace VSCodeEventBus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
         
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [Produces("application/json", "application/vnd.deepak.test.mediatype")]
        [HttpGet("{id}")]
        public async Task<ActionResult<string>> Get([FromHeader(Name="accept")] string mediaType ,int id)
        {
            if(mediaType.Equals("application/vnd.deepak.test.mediatype", StringComparison.OrdinalIgnoreCase))
            {
                return await Task.FromResult<string>(Utility.FileContent());
            }   
            return  await Task.FromResult<string>("value");
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
