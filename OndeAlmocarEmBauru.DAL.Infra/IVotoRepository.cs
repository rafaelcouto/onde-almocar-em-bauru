using OndeAlmocarEmBauru.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OndeAlmocarEmBauru.DAL.Infra
{
    public interface IVotoRepository
    {
        Task<Voto> PostVotoAsync(Voto voto);
        Task<IEnumerable<object>> GetVotosAgrupadoRestaurante(DateTime dataDe, DateTime dataAte);
        Task<List<Voto>> GetVotosAlunoPeriodo(string alu_ra, DateTime dataDe, DateTime dataAte);
        object GetRestauranteMaisVotado(DateTime dataDe, DateTime dataAte);
        Task<List<Voto>> GetVotosPeriodo(DateTime dataDe, DateTime dataAte);
    }
}
