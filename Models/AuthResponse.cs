using System;

namespace JwtBearerToken.AuthResources
{
    [Serializable]
    public class AuthResponse
    {
        public string token { get; set; }
        public int expiresIn { get; set; }
        public string userName { get; set; }
    }
}