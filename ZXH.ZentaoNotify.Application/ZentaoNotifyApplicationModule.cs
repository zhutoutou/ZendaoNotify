using Abp.Modules;
using Abp.Reflection.Extensions;
using ZXH.ZentaoNotify.Core;
using ZXH.ZentaoNotify.Quartz;

namespace ZXH.ZentaoNotify.Application
{
    [DependsOn(
        typeof(ZentaoNotifyCoreModule),
        typeof(ZentaoNotifyQuartzModule))]
    public class ZentaoNotifyApplicationModule:AbpModule
    {
        public override void Initialize()=> IocManager.RegisterAssemblyByConvention(typeof(ZentaoNotifyApplicationModule).GetAssembly());
    }
}