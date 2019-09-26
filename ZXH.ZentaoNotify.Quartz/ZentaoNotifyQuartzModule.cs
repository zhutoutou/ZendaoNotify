using Abp.Modules;
using Abp.Quartz;
using Abp.Reflection.Extensions;
using Quartz;
using ZXH.ZentaoNotify.Quartz.BaseJobs;

namespace ZXH.ZentaoNotify.Quartz
{
    [DependsOn(typeof(AbpQuartzModule))]
    public class ZentaoNotifyQuartzModule : AbpModule
    {
        public override void PreInitialize(){
            
        }
        public override void Initialize(){
            IocManager.RegisterAssemblyByConvention(typeof(ZentaoNotifyQuartzModule).GetAssembly());
        }
        public override async void PostInitialize(){
            var  quartzManager = IocManager.Resolve<IQuartzScheduleJobManager>();
            await quartzManager.ScheduleAsync<BugSearchJob>(job=>{
                job.WithIdentity("BugSearchJobIdentity","ZentaoGroup")
                    .WithDescription("A job to simply write logs.");
            },
            trigger=>{
                trigger.StartNow()
                    .WithSimpleSchedule(schedule=>{
                        schedule.RepeatForever()
                            .WithIntervalInHours(1)
                            .Build();
                    });
            });
        }
    }
}