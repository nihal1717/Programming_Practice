using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace FlowsAuthenticator.Models
{
    public class JWTTokencreator
    {
        private const string secret = "db3OIsj+BXE9NZDy0t8W3TcNekrF+2d/1sFnWG4HnV8TZY30iTOdtVWJG8abWvB1GlOgJuQZdcF2Luqm/hccMw==";
        
        //token generator method
        public string TokenGenerator(string userId)
        {
            try
            {
                int expireTime = 60;
                var symmetricKey = Convert.FromBase64String(secret);
                var tokenHandler = new JwtSecurityTokenHandler();

                var now = DateTime.UtcNow;

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[]
                    {
                    new Claim(ClaimTypes.Name, userId)
                }),
                    Expires = now.AddMinutes(Convert.ToInt32(expireTime)),

                    SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(symmetricKey),
                    SecurityAlgorithms.HmacSha256Signature)
                };
                var stoken = tokenHandler.CreateToken(tokenDescriptor);
                var token = tokenHandler.WriteToken(stoken);
                return token;
            }
            catch(Exception)
            {
                return "0";
            }
        }
    }
}