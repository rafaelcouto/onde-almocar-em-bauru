using OndeAlmocarEmBauru.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OndeAlmocarEmBauru.DAL.Infra
{
    public interface IVencedorRepository
    {
        Task<Vencedor> GetVencedorData(DateTime data);
        Task<Vencedor> RegistrarVencedor(Vencedor vencedor);
        Task<List<Vencedor>> GetVencedoresPeriodo(DateTime dataDe, DateTime dataAte);
    }
}
