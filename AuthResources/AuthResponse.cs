using System;

namespace AuthResources
{
    [Serializable]
    public class AuthResponse
    {
        public string token { get; set; }
        public string expiresIn { get; set; }
        public string userName { get; set; }
    }
}