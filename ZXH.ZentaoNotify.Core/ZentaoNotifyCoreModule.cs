using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Timing;
using Abp.Zero;
using ZXH.ZentaoNotify.Core.Configuration;
using ZXH.ZentaoNotify.Core.Timing;

namespace ZXH.ZentaoNotify.Core
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