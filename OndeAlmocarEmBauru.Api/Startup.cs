using OndeAlmocarEmBauru.Api.UoW;
using OndeAlmocarEmBauru.Api.UoW.Infra;
using OndeAlmocarEmBauru.BLL;
using OndeAlmocarEmBauru.BLL.Infra;
using OndeAlmocarEmBauru.DAL;
using OndeAlmocarEmBauru.DAL.DataBaseContext;
using OndeAlmocarEmBauru.DAL.Infra;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;

namespace OndeAlmocarEmBauru.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // DB CONTEXT
            services.AddScoped<IOndeAlmocarEmBauruDbContext, OndeAlmocarEmBauruDbContext>();

            // REPOSITORY
            services.AddScoped<IAlunoRepository, AlunoRepository>();
            services.AddScoped<IRestauranteRepository, RestauranteRepository>();
            services.AddScoped<IVotoRepository, VotoRepository>();
            services.AddScoped<IVencedorRepository, VencedorRepository>();

            // BLL
            services.AddScoped<IAlunoBLL, AlunoBLL>();
            services.AddScoped<IRestauranteBLL, RestauranteBLL>();
            services.AddScoped<IVotoBLL, VotoBLL>();
            services.AddScoped<IVencedorBLL, VencedorBLL>();

            // UoW
            services.AddScoped<ILoginUoW, LoginUoW>();
            services.AddScoped<IRestauranteUoW, RestauranteUoW>();
            services.AddScoped<IVotoUoW, VotoUoW>();
            services.AddScoped<IVencedorUoW, VencedorUoW>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                // FORMATACAO JSON (PASCAL CASE)
                .AddJsonOptions(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());

            // PASCALCASE = ExemploObjeto
            // CAMELCASE  = exemploObjeto
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
                app.UseHsts();
            
            app.UseHttpsRedirection();

            app.UseCors(builder => builder
                                    .AllowAnyOrigin()
                                    .AllowAnyMethod()
                                    .AllowAnyHeader()
                                    .AllowCredentials()
                        );

            app.UseMvc();
        }
    }
}
