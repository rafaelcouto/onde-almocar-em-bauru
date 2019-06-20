using OndeAlmocarEmBauru.BLL.Infra;
using OndeAlmocarEmBauru.DAL.Infra;
using OndeAlmocarEmBauru.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OndeAlmocarEmBauru.BLL
{
    public class VencedorBLL : IVencedorBLL
    {
        private readonly IVencedorRepository _vencedorRepository;
        private readonly IVotoRepository _votoRepository;

        public VencedorBLL(IVencedorRepository vencedorRepository, IVotoRepository votoRepository)
        {
            _vencedorRepository = vencedorRepository;
            _votoRepository = votoRepository;
        }

        public async Task<bool> vencedorDiaFoiDefinido() {
            Vencedor vencedor = await _vencedorRepository.GetVencedorData(DateTime.Now.Date);
            return await Task.FromResult(vencedor != null);
        }

        public async Task<Vencedor> definirVencedorDia()
        {
            try
            {
                DateTime dataDe = DateTime.Now.Date;
                DateTime dataAte = dataDe.AddHours(23).AddMinutes(59).AddSeconds(59);

                object restauranteMaisVotado = _votoRepository.GetRestauranteMaisVotado(dataDe, dataAte);

                Vencedor vencedor = new Vencedor();
                vencedor.RES_ID = (int) restauranteMaisVotado.GetType().GetProperty("RES_ID").GetValue(restauranteMaisVotado, null);
                vencedor.VCD_DATA = dataDe;

                return await _vencedorRepository.RegistrarVencedor(vencedor);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Vencedor> getVencedorDia()
        {
            return await _vencedorRepository.GetVencedorData(DateTime.Now.Date);
        }

    }
}
