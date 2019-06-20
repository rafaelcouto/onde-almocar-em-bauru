using OndeAlmocarEmBauru.DAL.Infra;
using OndeAlmocarEmBauru.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Linq;

namespace OndeAlmocarEmBauru.DAL.DataBaseContext
{
    public class OndeAlmocarEmBauruDbContext : DbContext, IOndeAlmocarEmBauruDbContext
    {
        private IConfiguration configuration;
        public OndeAlmocarEmBauruDbContext(IConfiguration config)
        {
            configuration = config;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connection = configuration.GetConnectionString("OndeAlmocarEmBauruDbBase");
            optionsBuilder.UseSqlServer(connection);
            base.OnConfiguring(optionsBuilder);
        }

        public void SetModified(object entity)
        {
            Entry(entity).State = EntityState.Modified;
        }


        public DbSet<Aluno> Aluno { get; set; }
        public IQueryable<Aluno> QueryAluno { get { return Aluno; } }

        public DbSet<Restaurante> Restaurante { get; set; }
        public IQueryable<Restaurante> QueryRestaurante { get { return Restaurante; } }

        public DbSet<Voto> Voto { get; set; }
        public IQueryable<Voto> QueryVoto { get { return Voto; } }

        public DbSet<Vencedor> Vencedor { get; set; }
        public IQueryable<Vencedor> QueryVencedor { get { return Vencedor; } }

    }
}
