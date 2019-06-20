using OndeAlmocarEmBauru.BLL.Infra;
using OndeAlmocarEmBauru.DAL.Infra;
using OndeAlmocarEmBauru.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OndeAlmocarEmBauru.BLL
{
    public class VotoBLL : IVotoBLL
    {
        private readonly IVotoRepository _votoRepository;
        private readonly IVencedorRepository _vencedorRepository;

        private readonly IVencedorBLL _vencedorBLL;

        public VotoBLL(IVotoRepository votoRepository, IVencedorRepository vencedorRepository, IVencedorBLL vencedorBLL)
        {
            _votoRepository = votoRepository;
            _vencedorRepository = vencedorRepository;
            _vencedorBLL = vencedorBLL;
        }

        public async Task<Voto> votar(Voto voto)
        {
            try
            {
                // #TODO: validação

                if (!await alunoPodeVotar(voto.ALU_RA)) {
                    return null;
                }
                
                voto.VOT_DATA = DateTime.Now;

                return await _votoRepository.PostVotoAsync(voto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> votacaoFoiFinalizada()
        {
            try
            {

                DateTime dataAtual = DateTime.Now;
                DateTime dataFim = dataAtual.Date.AddHours(11).AddMinutes(59).AddSeconds(59);

                return await Task.FromResult(dataAtual.TimeOfDay > dataFim.TimeOfDay);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> votacaoFoiIniciada()
        {
            try
            {

                DateTime dataAtual = DateTime.Now;
                DateTime dataInicio = dataAtual.Date.AddHours(10);

                return await Task.FromResult(dataAtual.TimeOfDay >= dataInicio.TimeOfDay);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> alunoJaVotou(string alu_ra)
        {
            try
            {
                
                DateTime dataDe = DateTime.Now.Date;
                DateTime dataAte = dataDe.AddHours(23).AddMinutes(59).AddSeconds(59);

                List<Voto> votos = await _votoRepository.GetVotosAlunoPeriodo(alu_ra, dataDe, dataAte);

                return (votos.Count > 0);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> alunoPodeVotar(string alu_ra)
        {
            if (!await votacaoFoiIniciada())
            {
                throw new Exception("Votação ainda não foi iniciada.");
            }

            if (await votacaoFoiFinalizada())
            {
                throw new Exception("Votação já foi finalizada.");
            }

            if (await alunoJaVotou(alu_ra))
            {
                throw new Exception("Aluno já votou hoje.");
            }

            return true;
        }

        public async Task<bool> haVotosDia()
        {
            try
            {
                DateTime dataDe = DateTime.Now.Date;
                DateTime dataAte = dataDe.AddHours(23).AddMinutes(59).AddSeconds(59);

                List<Voto> votos = await _votoRepository.GetVotosPeriodo(dataDe, dataAte);

                return (votos.Count > 0);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<Object>> resultadoParcial()
        {
            try
            {
                DateTime dataDe = DateTime.Now.Date;
                DateTime dataAte = dataDe.AddHours(23).AddMinutes(59).AddSeconds(59);

                return await _votoRepository.GetVotosAgrupadoRestaurante(dataDe, dataAte);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Vencedor> resultadoFinal()
        {
            try
            {
                return await _vencedorRepository.GetVencedorData(DateTime.Now.Date);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
