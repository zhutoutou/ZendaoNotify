using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using ZXH.ZentaoNotify.Core.Configuration;

namespace ZXH.ZentaoNotify.Web.Core.Configuration
{
    public static class HostingEnvironmentExtensions
    {
        public static IConfigurationRoot GetAppConfiguration(this IHostingEnvironment env)
        {
            return AppConfigurations.Get(env.ContentRootPath,env.EnvironmentName,env.IsDevelopment());
        }
    }
}