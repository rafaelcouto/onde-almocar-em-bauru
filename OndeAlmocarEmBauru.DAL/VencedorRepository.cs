using OndeAlmocarEmBauru.DAL.Infra;
using OndeAlmocarEmBauru.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OndeAlmocarEmBauru.DAL
{
    public class VencedorRepository : RepositoryBase<IOndeAlmocarEmBauruDbContext>, IVencedorRepository
    {
        public VencedorRepository(IOndeAlmocarEmBauruDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Vencedor> RegistrarVencedor(Vencedor vencedor)
        {
            try
            {
                _dbContext.Add(vencedor);
                await _dbContext.SaveChangesAsync();

                return vencedor;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Vencedor> GetVencedorData(DateTime data)
        {
            try
            {
                return await _dbContext.QueryVencedor
                    .Include(x => x.Restaurante)
                    .Where(x => x.VCD_DATA.Equals(data.Date))
                    .FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Vencedor>> GetVencedoresPeriodo(DateTime dataDe, DateTime dataAte)
        {
            try
            {
                return await _dbContext.QueryVencedor
                    .Where(x => x.VCD_DATA >= dataDe && x.VCD_DATA <= dataAte)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }

}
