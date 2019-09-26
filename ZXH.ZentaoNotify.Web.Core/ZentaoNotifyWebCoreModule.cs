using Abp.AspNetCore;
using Abp.AspNetCore.Configuration;
using Abp.Configuration.Startup;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using ZXH.ZentaoNotify.Application;
using ZXH.ZentaoNotify.Core;
using ZXH.ZentaoNotify.EntityFrameworkCore;
using ZXH.ZentaoNotify.Web.Core.Configuration;

namespace ZXH.ZentaoNotify.Web.Core
{
    [DependsOn(
        typeof(ZentaoNotifyApplicationModule),
        typeof(ZentaoNotifyEntityFrameworkModule),
        typeof(AbpAspNetCoreModule)
    )]
    public class ZentaoNotifyWebCoreModule : AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;
        public ZentaoNotifyWebCoreModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
                ZentaoNotifyConstants.ConnectionStringName
            );

            // TODO:将所有错误信息显示到客户端
            Configuration.Modules.AbpWebCommon().SendAllExceptionsToClients = true;

            // // Use database for language management
            // Configuration.Modules.Zero().LanguageManagement.EnableDbLocalization();


            Configuration.Modules.AbpAspNetCore()
                .CreateControllersForAppServices(
                    typeof(ZentaoNotifyWebCoreModule).GetAssembly()
                );
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(ZentaoNotifyWebCoreModule).GetAssembly());
        }

        public override void PostInitialize()
        {

        }
    }
}
