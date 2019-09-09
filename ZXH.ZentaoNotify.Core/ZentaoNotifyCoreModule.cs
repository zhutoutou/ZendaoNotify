using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Timing;
using Abp.Zero;
using ZXH.ZendaoNotify.Core.Configuration;
using ZXH.ZendaoNotify.Core.Timing;

namespace ZXH.ZendaoNotify.Core
{
    [DependsOn(typeof(AbpZeroCoreModule))]
    public class ZendaoNotifyCoreModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Settings.Providers.Add<AppSettingProvider>();
        }

        public override void Initialize() => IocManager.RegisterAssemblyByConvention(typeof(ZendaoNotifyCoreModule).GetAssembly());

        public override void PostInitialize() => IocManager.Resolve<AppTimes>().StartupTime = Clock.Now;
    }
}