using System;
using Abp.Dependency;
using Abp.Domain.Uow;
using Abp.EntityFrameworkCore.Uow;
using Abp.MultiTenancy;
using Microsoft.EntityFrameworkCore;
using ZXH.ZentaoNotify.EntityFrameworkCore.EntityFrameworkCore.Seed.Host;
using ZXH.ZentaoNotify.EntityFrameworkCore.EntityFrameworkCore.Seed.Tenants;

namespace ZXH.ZentaoNotify.EntityFrameworkCore.EntityFrameworkCore.Seed{
    public class SeedHelper{
        public static void SeedHostDb(IIocResolver iocResolve){
            WithDbContext<ZentaoNotifyDbContext>(iocResolve,SeedHostDb);
        }

        public static void SeedHostDb(ZentaoNotifyDbContext context){
            context.SuppressAutoSetTenantId = true;

            // Host Seed
            new InitialHostDbBuilder(context).Create();

            // Default tenant seed (in host database)
            new DefaultTenantBuilder(context).Create();
        }

        public static void WithDbContext<TDbContext>(IIocResolver iocResolver,Action<TDbContext> contextAction)
            where TDbContext:DbContext
        {
            using(var uowManager = iocResolver.ResolveAsDisposable<IUnitOfWorkManager>()){
                using(var uow = uowManager.Object.Begin(System.Transactions.TransactionScopeOption.Suppress)){
                    var context = uowManager.Object.Current.GetDbContext<TDbContext>(MultiTenancySides.Host);

                    contextAction(context);

                    uow.Complete();
                }
            }

        }
    }
}