
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AuthResources;
using Microsoft.IdentityModel.Tokens;

namespace jwtBearerToken.AuthResources
{
    public class AuthManager
    {
        public AuthResponse Authenticate(string username, string password)
        {
            if (username != "admin" && password != "admin123")
            {
                return null;
            }

            var tokenTimeStamp = DateTime.UtcNow.AddMinutes(Constants.TOKEN_VALIDITY_MINS);

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Constants.SECRET_KEY);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new List<Claim>
                {
                    new Claim("username", username),
                    new  Claim(ClaimTypes.PrimaryGroupSid, "UserGroup"),
                }),
                Expires = tokenTimeStamp,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var seucrityToken = tokenHandler.CreateToken(tokenDescriptor);
            var token = tokenHandler.WriteToken(seucrityToken);

            return new AuthResponse
            {
                token = token,
                userName = username,
                expiresIn = (int) tokenTimeStamp.Subtract(DateTime.UtcNow).TotalSeconds
            };
        }
    }
}