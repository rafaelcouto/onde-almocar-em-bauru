using OndeAlmocarEmBauru.Entities;
using System.Threading.Tasks;

namespace OndeAlmocarEmBauru.DAL.Infra
{
    public interface IAlunoRepository
    {
        Task<Aluno> GetLoginAsync(string ra, string senha);
    }
}
