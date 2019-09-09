using Abp.Modules;
using Abp.Dependency;
using Abp.EntityFrameworkCore.Configuration;
using ZXH.ZendaoNotify.Core;
using Abp.Reflection.Extensions;

namespace ZXH.ZendaoNotify.EntityFrameworkCore.EntityFrameworkCore
{
    public class ZendaoNotifyEntityFrameworkModule : AbpModule
    {
        public bool SkipDbContextRegistration { get; set; }
        public bool SkipDbContextSeed { get; set; }

        public bool IsTestInMemory {get;set;}
        public override void PreInitialize()
        {
            if (!SkipDbContextRegistration)
            {
                Configuration.Modules.AbpEfCore().AddDbContext<ZendaoNotifyDbContext>(options =>
                {
                    if (options.ExistingConnection != null)
                    {
                        ZendaoNotifyDbContextConfigure.Configure(options.DbContextOptions, options.ExistingConnection);
                    }
                    else
                    {
                        if(IsTestInMemory)
                            ZendaoNotifyDbContextConfigure.ConfigureInMemory(options.DbContextOptions,ZendaoNotifyConstants.LocalizationSourceName);
                        else
                            ZendaoNotifyDbContextConfigure.Configure(options.DbContextOptions, options.ConnectionString);
                    }
                });
            }
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(ZendaoNotifyEntityFrameworkModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            if(!SkipDbContextSeed){
                
            }
        }
    }
}