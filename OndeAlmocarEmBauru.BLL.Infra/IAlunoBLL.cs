using OndeAlmocarEmBauru.Entities;
using System.Threading.Tasks;

namespace OndeAlmocarEmBauru.BLL.Infra
{
    public interface IAlunoBLL
    {
        Task<Aluno> GetLoginAsync(string ra, string senha);
    }
}
