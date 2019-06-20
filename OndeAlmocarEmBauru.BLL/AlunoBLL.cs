using OndeAlmocarEmBauru.BLL.Infra;
using OndeAlmocarEmBauru.DAL.Infra;
using OndeAlmocarEmBauru.Entities;
using System;
using System.Threading.Tasks;

namespace OndeAlmocarEmBauru.BLL
{
    public class AlunoBLL : IAlunoBLL
    {
        private readonly IAlunoRepository _alunoRepository;
        public AlunoBLL(IAlunoRepository alunoRepository)
        {
            _alunoRepository = alunoRepository;
        }

        public async Task<Aluno> GetLoginAsync(string ra, string senha)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(ra))
                {
                    throw new Exception("Preencha o login de usuário.");
                }

                if (string.IsNullOrWhiteSpace(senha))
                {
                    throw new Exception("Preencha a senha de usuário.");
                }

                return await _alunoRepository.GetLoginAsync(ra, senha);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
