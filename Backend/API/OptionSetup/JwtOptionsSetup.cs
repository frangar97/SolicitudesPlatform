using Infrastructure.Authentication;
using Microsoft.Extensions.Options;

namespace API.OptionSetup
{
    public class JwtOptionsSetup : IConfigureOptions<JwtOptions>
    {
        private readonly IConfiguration _configuration;
        public JwtOptionsSetup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void Configure(JwtOptions options)
        {
            _configuration.GetSection("jwt").Bind(options);
        }
    }
}
