
using System;

namespace JwtBearerToken.Models
{
    [Serializable]
    public class AuthRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}