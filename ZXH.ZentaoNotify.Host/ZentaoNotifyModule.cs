using Abp.Modules;
using Abp.Reflection.Extensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using ZXH.ZentaoNotify.Web.Core;
using ZXH.ZentaoNotify.Web.Core.Configuration;

namespace ZXH.ZentaoNotify.Host
{
    [DependsOn(
        typeof(ZentaoNotifyWebCoreModule))]
    public class ZentaoNotifyModule : AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;
        public ZentaoNotifyModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void PreInitialize()
        {

        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(ZentaoNotifyModule).GetAssembly());
        }

        public override void PostInitialize()
        {

        }
    }
}