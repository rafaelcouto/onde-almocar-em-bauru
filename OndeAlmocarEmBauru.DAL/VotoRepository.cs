using OndeAlmocarEmBauru.DAL.Infra;
using OndeAlmocarEmBauru.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OndeAlmocarEmBauru.DAL
{
    public class VotoRepository : RepositoryBase<IOndeAlmocarEmBauruDbContext>, IVotoRepository
    {
        public VotoRepository(IOndeAlmocarEmBauruDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Voto> PostVotoAsync(Voto voto)
        {
            try
            {
                _dbContext.Add(voto);
                await _dbContext.SaveChangesAsync();

                return voto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<object>> GetVotosAgrupadoRestaurante(DateTime dataDe, DateTime dataAte)
        {
            try
            {
                return await _dbContext.QueryVoto
                    .Where(x => x.VOT_DATA >= dataDe && x.VOT_DATA <= dataAte)
                    .Include(r => r.Restaurante)
                    .GroupBy(g => new {
                        g.RES_ID,
                        g.Restaurante.RES_NOME
                    })
                    .Select(group => new {
                        RES_ID = group.Key.RES_ID,
                        RES_NOME = group.Key.RES_NOME,
                        QUANTIDADE_VOTOS = group.Count()
                    }).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public object GetRestauranteMaisVotado(DateTime dataDe, DateTime dataAte)
        {
            try
            {
                return _dbContext.QueryVoto
                    .Where(x => x.VOT_DATA >= dataDe && x.VOT_DATA <= dataAte)
                    .GroupBy(g => new {
                        g.RES_ID,
                    })
                    .Select(group => new {
                        RES_ID = group.Key.RES_ID,
                        QUANTIDADE_VOTOS = group.Count()
                    })
                    // Ordena pelo mais votado
                    .OrderByDescending(o => o.QUANTIDADE_VOTOS)
                    // Depois ordena aleatóriamente caso haja mais de um com a mesma quantidade de votos
                    .ThenBy(o => Guid.NewGuid())
                    .FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Voto>> GetVotosAlunoPeriodo(string alu_ra, DateTime dataDe, DateTime dataAte)
        {
            try
            {
                return  await _dbContext.QueryVoto
                    .Where(x => x.ALU_RA.Equals(alu_ra))
                    .Where(x => x.VOT_DATA >= dataDe && x.VOT_DATA <= dataAte)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Voto>> GetVotosPeriodo(DateTime dataDe, DateTime dataAte)
        {
            try
            {
                return await _dbContext.QueryVoto
                    .Where(x => x.VOT_DATA >= dataDe && x.VOT_DATA <= dataAte)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }

}
