using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PersonalNotesAPI.Auth
{
    public class AuthTokenUtil
    {
        public static JwtSecurityToken GetJwtSecurityToken(string userName, IConfiguration config)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JWTAuthentication:SecretKey"]));

            var claims = new Claim[]
            {
                new Claim(ClaimTypes.Name, userName),
                new Claim("DisplayName", userName.Split('@')[0]),
                new Claim("UserName", userName),
                new Claim(JwtRegisteredClaimNames.Email, userName)
            };

            var token = new JwtSecurityToken(
                issuer: config["JWTAuthentication:Issuer"],
                audience: config["JWTAuthentication:Audience"],
                claims: claims,
                notBefore: DateTime.UtcNow,
                expires: DateTime.Now.AddMinutes(20),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
            );
            return token;
        }

        public static string GetJwtSecurityTokenString(string userName, IConfiguration config)
        {
            var token = GetJwtSecurityToken(userName, config);
            var result = new JwtSecurityTokenHandler().WriteToken(token);
            return result;
        }
    }
}
