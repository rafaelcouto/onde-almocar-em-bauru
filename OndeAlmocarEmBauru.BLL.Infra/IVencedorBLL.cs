using OndeAlmocarEmBauru.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OndeAlmocarEmBauru.BLL.Infra
{
    public interface IVencedorBLL
    {
        Task<bool> vencedorDiaFoiDefinido();
        Task<Vencedor> definirVencedorDia();
        Task<Vencedor> getVencedorDia();
    }
}
