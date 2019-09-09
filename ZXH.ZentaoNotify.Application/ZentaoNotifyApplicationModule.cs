using Abp.Modules;
using Abp.Reflection.Extensions;
using ZXH.ZentaoNotify.Core;
using ZXH.ZentaoNotify.Quartz;

namespace ZXH.ZentaoNotify.Application
{
    [DependsOn(
        typeof(ZendaoNotifyCoreModule),
        typeof(ZendaoNotifyQuartzModule))]
    public class ZendaoNotifyApplicationModule:AbpModule
    {
        public override void Initialize()=> IocManager.RegisterAssemblyByConvention(typeof(ZendaoNotifyApplicationModule).GetAssembly());
    }
}