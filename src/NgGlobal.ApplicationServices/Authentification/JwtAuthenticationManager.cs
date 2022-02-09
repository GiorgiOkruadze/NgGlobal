using Microsoft.IdentityModel.Tokens;
using NgGlobal.ApplicationServices.Authentication.Abstraction;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace NgGlobal.ApplicationServices.Authentication.Authentication
{
    public class JwtAuthenticationManager : IJwtAuthenticationManager
    {
        private readonly string _key = default;
        public JwtAuthenticationManager(string key)
        {
            _key = key;
        }


        public string Authenticate(bool status,string email)
        {
            if (status)
            {
                var tokenKey = Encoding.ASCII.GetBytes(_key);
                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenDescriptor = new SecurityTokenDescriptor()
                {
                    Subject = new ClaimsIdentity(new List<Claim>()
                    {
                        new Claim(ClaimTypes.Name,email)
                    }),
                    Expires = DateTime.UtcNow.AddHours(12),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);
                return tokenHandler.WriteToken(token);
            }
            return string.Empty;
        }

    }
}
