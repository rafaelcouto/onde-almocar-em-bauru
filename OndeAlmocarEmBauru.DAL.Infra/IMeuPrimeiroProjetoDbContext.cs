using OndeAlmocarEmBauru.Entities;
using System.Linq;

namespace OndeAlmocarEmBauru.DAL.Infra
{
    public interface IOndeAlmocarEmBauruDbContext : IDataBaseContext
    {
        IQueryable<Aluno> QueryAluno { get; }
        IQueryable<Restaurante> QueryRestaurante { get; }
        IQueryable<Voto> QueryVoto { get; }
        IQueryable<Vencedor> QueryVencedor { get; }
    }
}
