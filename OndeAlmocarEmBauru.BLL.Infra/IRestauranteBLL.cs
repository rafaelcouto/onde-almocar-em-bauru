using OndeAlmocarEmBauru.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OndeAlmocarEmBauru.BLL.Infra
{
    public interface IRestauranteBLL
    {
        Task<List<Restaurante>> GetRestaurantesDisponiveis();
    }
}
