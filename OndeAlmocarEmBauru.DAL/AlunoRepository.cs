using OndeAlmocarEmBauru.DAL.Infra;
using OndeAlmocarEmBauru.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace OndeAlmocarEmBauru.DAL
{
    public class AlunoRepository : RepositoryBase<IOndeAlmocarEmBauruDbContext>, IAlunoRepository
    {
        public AlunoRepository(IOndeAlmocarEmBauruDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Aluno> GetLoginAsync(string ra, string senha)
        {
            try
            {
                return await _dbContext.QueryAluno
                    .Where(x => x.ALU_RA.Equals(ra) && x.ALU_SENHA.Equals(senha)).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}
