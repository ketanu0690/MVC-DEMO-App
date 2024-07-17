using DemoMVCApplication.Models.Contracts;

namespace DemoMVCApplication.Models.Dto
{
    public class ApplicationSettings : IApplicationSettings
    {
        private readonly IConfiguration _configuration;
        public ApplicationSettings(IConfiguration configuration)
        {
           _configuration = configuration;
        }
        public string ApiUrl
        {
            get
            {
                return _configuration["ApplicationSettings:ApiUrl"];
            }
        }
    }
}
