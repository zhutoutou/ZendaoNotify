namespace ZXH.ZendaoNotify.EntityFrameworkCore.EntityFrameworkCore.Seed.Host
{
    public class InitialHostDbBuilder
    {
        private readonly ZendaoNotifyDbContext _context;

        public InitialHostDbBuilder(ZendaoNotifyDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            _context.SaveChanges();
        }
    }
}