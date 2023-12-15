using Core.Services;

namespace Infrastructure.Services
{
    public class HashService : IHashService
    {
        public bool CompareStringHash(string key, string value)
        {
            bool isEqual = BCrypt.Net.BCrypt.Verify(key, value);
            return isEqual;
        }

        public string GenerateHash(string key)
        {
            string hash = BCrypt.Net.BCrypt.HashPassword(key);
            return hash;
        }
    }
}
