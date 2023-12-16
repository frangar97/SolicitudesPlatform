namespace Core.Services
{
    public interface IJwtService
    {
        string GenerateJWT(int id, string user);
    }
}
