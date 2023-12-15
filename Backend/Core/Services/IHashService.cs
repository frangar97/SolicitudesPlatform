namespace Core.Services
{
    public interface IHashService
    {
        string GenerateHash(string key);
        bool CompareStringHash(string key, string value);
    }
}
