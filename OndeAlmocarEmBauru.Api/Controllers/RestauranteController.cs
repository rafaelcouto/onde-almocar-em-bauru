using OndeAlmocarEmBauru.Api.UoW.Infra;
using OndeAlmocarEmBauru.Entities;
using OndeAlmocarEmBauru.Helpers;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OndeAlmocarEmBauru.Api.Controllers
{
    [ApiController]
    public class RestauranteController : ControllerBase
    {
        private IRestauranteUoW _restauranteUoW;

        public RestauranteController(IRestauranteUoW restauranteUoW)
        {
            _restauranteUoW = restauranteUoW;
        }

        [Route("api/restaurantes"), HttpGet]
        public async Task<IActionResult> GetRestaurantes()
        {
            var response = new RestaurantesResponse();

            try
            {
                response.restaurantes = await _restauranteUoW.restauranteBLL.GetRestaurantesDisponiveis();
                response.mensagem = "Requisição realizada com sucesso";
                response.sucesso = true;
            }
            catch (Exception ex)
            {
                response.mensagem = ex.Message;
                response.sucesso = false;
            }

            return Ok(response);
        }
    }

}