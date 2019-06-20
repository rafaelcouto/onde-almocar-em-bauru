using OndeAlmocarEmBauru.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OndeAlmocarEmBauru.BLL.Infra
{
    public interface IVotoBLL
    {
        Task<Voto> votar(Voto voto);
        Task<bool> votacaoFoiIniciada();
        Task<bool> votacaoFoiFinalizada();
        Task<bool> alunoJaVotou(string alu_ra);
        Task<bool> alunoPodeVotar(string alu_ra);
        Task<bool> haVotosDia();
        Task<IEnumerable<Object>> resultadoParcial();
        Task<Vencedor> resultadoFinal();
    }
}
