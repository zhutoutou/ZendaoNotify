using Abp.Modules;
using Abp.Reflection.Extensions;
using ZXH.ZendaoNotify.Core;
using ZXH.ZendaoNotify.Quartz;

namespace ZXH.ZendaoNotify.Application
{
    [DependsOn(
        typeof(ZendaoNotifyCoreModule),
        typeof(ZendaoNotifyQuartzModule))]
    public class ZendaoNotifyApplicationModule:AbpModule
    {
        public override void Initialize()=> IocManager.RegisterAssemblyByConvention(typeof(ZendaoNotifyApplicationModule).GetAssembly());
    }
}