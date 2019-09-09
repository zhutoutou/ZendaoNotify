using System;
using Abp.Modules;
using Abp.Quartz;
using Abp.Reflection.Extensions;
using Quartz;
using ZXH.ZendaoNotify.Quartz.BaseJobs;

namespace ZXH.ZendaoNotify.Quartz
{
    [DependsOn(typeof(AbpQuartzModule))]
    public class ZendaoNotifyQuartzModule : AbpModule
    {
        public override void PreInitialize(){
            
        }
        public override void Initialize(){
            IocManager.RegisterAssemblyByConvention(typeof(ZendaoNotifyQuartzModule).GetAssembly());
        }
        public override async void PostInitialize(){
            var  quartzManager = IocManager.Resolve<IQuartzScheduleJobManager>();
            await quartzManager.ScheduleAsync<BugSearchJob>(job=>{
                job.WithIdentity("BugSearchJobIdentity","ZendaoGroup")
                    .WithDescription("A job to simply write logs.");
            },
            trigger=>{
                trigger.StartNow()
                    .WithSimpleSchedule(schedule=>{
                        schedule.RepeatForever()
                            .WithIntervalInSeconds(5)
                            .Build();
                    });
            });
        }
    }
}