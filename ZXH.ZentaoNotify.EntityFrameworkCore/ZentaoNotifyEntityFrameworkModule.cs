using Abp.EntityFrameworkCore.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using ZXH.ZentaoNotify.Core;
using ZXH.ZentaoNotify.EntityFrameworkCore.EntityFrameworkCore;

namespace ZXH.ZentaoNotify.EntityFrameworkCore
{
    public class ZentaoNotifyEntityFrameworkModule : AbpModule
    {
        public bool SkipDbContextRegistration { get; set; }
        public bool SkipDbContextSeed { get; set; }

        public bool IsTestInMemory {get;set;}
        public override void PreInitialize()
        {
            if (!SkipDbContextRegistration)
            {
                Configuration.Modules.AbpEfCore().AddDbContext<ZentaoNotifyDbContext>(options =>
                {
                    if (options.ExistingConnection != null)
                    {
                        ZentaoNotifyDbContextConfigure.Configure(options.DbContextOptions, options.ExistingConnection);
                    }
                    else
                    {
                        if(IsTestInMemory)
                            ZentaoNotifyDbContextConfigure.ConfigureInMemory(options.DbContextOptions,ZentaoNotifyConstants.LocalizationSourceName);
                        else
                            ZentaoNotifyDbContextConfigure.Configure(options.DbContextOptions, options.ConnectionString);
                    }
                });
            }
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(ZentaoNotifyEntityFrameworkModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            if(!SkipDbContextSeed){
                
            }
        }
    }
}