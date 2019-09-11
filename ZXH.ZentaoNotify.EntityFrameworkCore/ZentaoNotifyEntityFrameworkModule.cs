using System.Configuration;
using System.Linq;
using Abp.EntityFrameworkCore.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Configuration;
using ZXH.ZentaoNotify.Core;
using ZXH.ZentaoNotify.Core.Configuration;
using ZXH.ZentaoNotify.EntityFrameworkCore.EntityFrameworkCore;
using ZXH.ZentaoNotify.EntityFrameworkCore.EntityFrameworkCore.Seed;

namespace ZXH.ZentaoNotify.EntityFrameworkCore
{
    public class ZentaoNotifyEntityFrameworkModule : AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;
        public bool SkipDbContextRegistration { get; set; }
        public bool SkipDbContextSeed { get; set; }

        public ZentaoNotifyEntityFrameworkModule(IHostingEnvironment env){
            _env = env;
            _appConfiguration = AppConfigurations.Get(env.ContentRootPath,env.EnvironmentName,env.IsDevelopment());
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
                        if (!ConfigurationManager.ConnectionStrings.Any()){
                            Configuration.DefaultNameOrConnectionString = ZentaoNotifyConstants.DefaultMemoryConnectionString;
                            ZentaoNotifyDbContextConfigure.ConfigureInMemory(options.DbContextOptions, ZentaoNotifyConstants.LocalizationSourceName);
                        }
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
            if (!SkipDbContextSeed)
            {
                SeedHelper.SeedHostDb(IocManager);
            }
        }
    }
}