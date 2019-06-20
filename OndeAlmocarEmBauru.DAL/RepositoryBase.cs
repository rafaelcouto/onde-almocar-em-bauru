using OndeAlmocarEmBauru.DAL.Infra;

namespace OndeAlmocarEmBauru.DAL
{
    public abstract class RepositoryBase<TContext> where TContext : IOndeAlmocarEmBauruDbContext
    {
        protected TContext _dbContext;

        public RepositoryBase(TContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
