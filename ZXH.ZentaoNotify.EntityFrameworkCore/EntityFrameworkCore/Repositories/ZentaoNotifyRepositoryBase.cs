using Abp.Domain.Entities;
using Abp.EntityFrameworkCore;
using Abp.EntityFrameworkCore.Repositories;
using ZXH.ZentaoNotify.EntityFrameworkCore.EntityFrameworkCore;

namespace ZXH.ZentaoNotify.EntityframeworkCore.EntityFrameworkCore.Repositories
{
    /// <summary>
    /// Base class for custom repositories of the application.
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TPrimaryKey"></typeparam>
    public abstract class ZentaoNotifyRepositoryBase<TEntity, TPrimaryKey> : EfCoreRepositoryBase<ZentaoNotifyDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected ZentaoNotifyRepositoryBase(IDbContextProvider<ZentaoNotifyDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        // Add your common methods for all repositories
    }

    /// <summary>
    /// Base class for custom repositories of the application.
    /// This is shortcut of <see cref="ZentaoNotifyRepositoryBase{TEntity,TPrimaryKey}"/> for <see cref="int"/>  primary key.
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public abstract class ZentaoNotifyRepositoryBase<TEntity> : ZentaoNotifyRepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        protected ZentaoNotifyRepositoryBase(IDbContextProvider<ZentaoNotifyDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
            
        }

        // Do not add any method here,add to the class above (since this inherits it)!!!
    }
}