using OndeAlmocarEmBauru.DAL.Infra;
using OndeAlmocarEmBauru.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OndeAlmocarEmBauru.DAL
{
    public class RestauranteRepository : RepositoryBase<IOndeAlmocarEmBauruDbContext>, IRestauranteRepository
    {
        public RestauranteRepository(IOndeAlmocarEmBauruDbContext dbContext) : base(dbContext)
        {
        }
        
        public async Task<List<Restaurante>> GetRestaurantes()
        {
            try
            {
                return await _dbContext.QueryRestaurante.ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}
