using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;

namespace FlowsAuthenticator.Models
{
    public class SimpleJWTValidator
    {
        private const string secret = "db3OIsj+BXE9NZDy0t8W3TcNekrF+2d/1sFnWG4HnV8TZY30iTOdtVWJG8abWvB1GlOgJuQZdcF2Luqm/hccMw==";

        public static ClaimsPrincipal GetPrincipal(string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var jwtToken = tokenHandler.ReadToken(token) as JwtSecurityToken;

                if (jwtToken == null)
                    return null;

                var symmetricKey = Convert.FromBase64String(secret);

                var validationParameters = new TokenValidationParameters()
                {
                    RequireExpirationTime = true,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    IssuerSigningKey = new SymmetricSecurityKey(symmetricKey)
                };

                SecurityToken securityToken;
                var principal = tokenHandler.ValidateToken(token, validationParameters, out securityToken);

                return principal;
            }
            catch (Exception)
            {
                return null;
            }
        }
        private static bool ValidateToken(string token, out string userName)
        {
            userName = null;
            var simplePrinciple = GetPrincipal(token);
            var identity = simplePrinciple.Identity as ClaimsIdentity;

            if (identity == null || !identity.IsAuthenticated)
                return false;

            var usernameClaim = identity.FindFirst(ClaimTypes.Name);
            userName = usernameClaim?.Value;

            if (string.IsNullOrEmpty(userName))
                return false;

            // More validate to check whether username exists in system

            return true;
        }
        public bool AuthenticateJwtToken(string token)
        {
            string username;

            try
            {
                if (ValidateToken(token, out username))
                {
                    // based on username to get more information from database 
                    // in order to build local identity
                    var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, username)
                     // Add more claims if needed: Roles, ...
                };

                    var identity = new ClaimsIdentity(claims, "Jwt");
                    IPrincipal user = new ClaimsPrincipal(identity);

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception)
            {
                return false;
            }
        }
    }
}