using OndeAlmocarEmBauru.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OndeAlmocarEmBauru.DAL.Infra
{
    public interface IRestauranteRepository
    {
        Task<List<Restaurante>> GetRestaurantes();
    }
}
