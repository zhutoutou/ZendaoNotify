using Abp.AspNetCore;
using Abp.AspNetCore.Configuration;
using Abp.Configuration.Startup;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using ZXH.ZendaoNotify.Application;
using ZXH.ZendaoNotify.Web.Core.Configuration;

namespace ZXH.ZendaoNotify.Web.Core
{
    [DependsOn(
        typeof(ZendaoNotifyApplicationModule),
        typeof(AbpAspNetCoreModule)
    )]
    public class ZendaoNotifyWebCoreModule : AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;
        public ZendaoNotifyWebCoreModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void PreInitialize()
        {
            // Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
            //     // Constants
            // )

            // TODO:将所有错误信息显示到客户端
            Configuration.Modules.AbpWebCommon().SendAllExceptionsToClients = true;

            // // Use database for language management
            // Configuration.Modules.Zero().LanguageManagement.EnableDbLocalization();
            

            Configuration.Modules.AbpAspNetCore()
                .CreateControllersForAppServices(
                    typeof(ZendaoNotifyWebCoreModule).GetAssembly()
                );
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(ZendaoNotifyWebCoreModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            
        }
    }
}
