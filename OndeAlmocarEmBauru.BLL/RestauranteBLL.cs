using OndeAlmocarEmBauru.BLL.Infra;
using OndeAlmocarEmBauru.DAL.Infra;
using OndeAlmocarEmBauru.Entities;
using OndeAlmocarEmBauru.Helpers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OndeAlmocarEmBauru.BLL
{
    public class RestauranteBLL : IRestauranteBLL
    {
        private readonly IRestauranteRepository _restauranteRepository;
        private readonly IVencedorRepository _vencedorRepository;

        public RestauranteBLL(IRestauranteRepository restauranteRepository, IVencedorRepository vencedorRepository)
        {
            _restauranteRepository = restauranteRepository;
            _vencedorRepository = vencedorRepository;
        }
        
        public async Task<List<Restaurante>> GetRestaurantesDisponiveis()
        {
            try
            {
                List<Restaurante> restaurantes = await _restauranteRepository.GetRestaurantes();
                List<Restaurante> disponiveis = new List<Restaurante>();

                // Buscando vencedores da semana
                DateTime dataDe = DateHelper.FirstDayOfWeek(DateTime.Now.Date);
                DateTime dateAte = DateHelper.LastDayOfWeek(DateTime.Now.Date);
                List<Vencedor> vencedores = await _vencedorRepository.GetVencedoresPeriodo(dataDe, dateAte);

                bool disponivel;

                // Armazenando apenas os restaurantes que não foram vencedores na semana
                foreach(Restaurante restaurante in restaurantes)
                {
                    disponivel = true;
                    foreach (Vencedor vencedor in vencedores) {
                        if (restaurante.RES_ID == vencedor.RES_ID)
                        {
                            disponivel = false;
                            break;
                        }
                    }

                    if (disponivel)
                    {
                        disponiveis.Add(restaurante);
                    }
                }

                return disponiveis;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
