using FlowsAuthenticator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FlowsAuthenticator.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(string id)
        {
            return "value";
        }

        // POST api/values
        public string Post([FromBody] string value)
        {
            string response = string.Empty;
            string[] name = new string[3] { "Alpha", "Beta", "Gamma" };
            var find = Array.Find(name, item => item == value);

            if(find!=null && find==value)
            {
                JWTTokencreator tokencreator = new JWTTokencreator();
                response = tokencreator.TokenGenerator(value);
            }
            else
            {
                return "User is not present in list";
            }
            if (response!="0")
            {
                return response;
            }
            else
            {
                return "User is not present in list";
            }
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
