namespace ZXH.ZentaoNotify.EntityFrameworkCore.EntityFrameworkCore.Seed.Host
{
    public class DefaultEditionCreator
    {
        private readonly ZentaoNotifyDbContext _context; 

        public DefaultEditionCreator(ZentaoNotifyDbContext context){
            _context = context;
            
        }
    }
}