using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DIDemo.Infrastructure;

namespace DIDemo.Controllers
{
    public class ValuesController : ApiController
    {
        private readonly ILogger logger;

        public ValuesController(ILogger logger)
        {
            this.logger = logger;
        }

        // GET api/values
        public IEnumerable<string> Get()
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            
            var values = new string[] { "value1", "value2" };

            stopWatch.Stop();
            this.logger.Log(string.Format("Time taken - {0}", stopWatch.Elapsed.TotalSeconds));
            

            return values;
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
