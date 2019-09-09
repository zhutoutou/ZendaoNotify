namespace ZXH.ZentaoNotify.EntityframeworkCore.EntityFrameworkCore.Repositories
{
    public abstract class ZentaoNotifyRepositoryBase<TEntity,TPrimaryKey>:EfCoreRepositoryBase<ZentaoNotifyDbContext,TEntity,TPrimaryKey>
        where TEntity:class,TEntity<TPrimaryKey>
    {
        protected ZentaoNotifyRepositoryBase(IDbContextProvider<ZentaoNotifyDbContext> dbContextProvider)
            :base(dbContextProvider)
        {

        }

        // Add your common methods for all repositories
    }
}