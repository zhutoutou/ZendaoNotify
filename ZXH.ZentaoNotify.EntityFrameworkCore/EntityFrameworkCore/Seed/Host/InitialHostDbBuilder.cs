namespace ZXH.ZentaoNotify.EntityFrameworkCore.EntityFrameworkCore.Seed.Host
{
    public class InitialHostDbBuilder
    {
        private readonly ZentaoNotifyDbContext _context;

        public InitialHostDbBuilder(ZentaoNotifyDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            _context.SaveChanges();
        }
    }
}