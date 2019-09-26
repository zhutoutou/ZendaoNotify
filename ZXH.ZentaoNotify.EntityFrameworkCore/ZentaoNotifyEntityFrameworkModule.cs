using Abp.EntityFrameworkCore.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Zero.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using System.Configuration;
using ZXH.ZentaoNotify.Core;
using ZXH.ZentaoNotify.EntityFrameworkCore.EntityFrameworkCore;
using ZXH.ZentaoNotify.EntityFrameworkCore.EntityFrameworkCore.Seed;

namespace ZXH.ZentaoNotify.EntityFrameworkCore
{
    [DependsOn(
        typeof(ZentaoNotifyCoreModule),
        typeof(AbpZeroCoreEntityFrameworkCoreModule))]
    public class ZentaoNotifyEntityFrameworkModule : AbpModule
    {
        private readonly IHostingEnvironment _env;
        public bool SkipDbContextRegistration { get; set; }
        public bool SkipDbContextSeed { get; set; }

        public ZentaoNotifyEntityFrameworkModule(IHostingEnvironment env){
            _env = env;
        }
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
            if (!SkipDbContextSeed)
            {
                SeedHelper.SeedHostDb(IocManager);
            }
        }
    }
}