using FlowsAuthenticator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FlowsAuthenticator.Controllers
{
    public class TokenValidatorController : ApiController
    {
        //TokenModel model = new TokenModel();
        SimpleJWTValidator validator = new SimpleJWTValidator();
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        public HttpResponseMessage Post([FromBody] TokenModel value)
        {
            try
            {
                if (value != null && value.Token != null)
                {
                    bool valid = validator.AuthenticateJwtToken(value.Token);
                    if(valid)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, "Access Authorized");
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.Unauthorized, "Unauthorized Access");
                    }
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.Unauthorized, "Unauthorized Access");
                }
            }
            catch(Exception)
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized, "Unauthorized Access");
            }
        }
    }
}
