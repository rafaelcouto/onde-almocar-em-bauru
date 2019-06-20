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
    public class VotoController : ControllerBase
    {
        private IVotoUoW _votoUoW;
        private IVencedorUoW _vencedorUoW;

        public VotoController(IVotoUoW votoUoW, IVencedorUoW vencedorUoW)
        {
            _votoUoW = votoUoW;
            _vencedorUoW = vencedorUoW;
        }

        [Route("api/votar"), HttpPost]
        public async Task<IActionResult> votar([FromBody]Voto voto)
        {
            var response = new ResponseContent();
            try
            {
                await _votoUoW.votoBLL.votar(voto);
                response.mensagem = "Voto computado com sucesso.";
                response.sucesso = true;
            }
            catch (Exception ex)
            {
                response.mensagem = ex.Message;
                response.sucesso = false;
            }

            return Ok(response);
        }

        [Route("api/votar/verificar"), HttpGet]
        public async Task<IActionResult> verificar(string alu_ra)
        {
            var response = new ResponseContent();

            try
            {

                if (await _votoUoW.votoBLL.alunoPodeVotar(alu_ra))
                {
                    response.mensagem = "Aluno liberado para votar.";
                    response.sucesso = true;
                }

            }
            catch (Exception ex)
            {
                response.mensagem = ex.Message;
                response.sucesso = false;
            }

            return Ok(response);
        }

        [Route("api/resultado"), HttpGet]
        public async Task<IActionResult> resultado()
        {
            var response = new ResultadoVotacaoResponse();

            try
            {

                if (!await _votoUoW.votoBLL.votacaoFoiIniciada())
                {
                    response.mensagem = "A votação ainda não foi iniciada";
                    response.sucesso = false;
                    return Ok(response);
                }

                if (!await _votoUoW.votoBLL.votacaoFoiFinalizada())
                {
                    response.mensagem = "Resultado parcial";
                    response.parcial = await _votoUoW.votoBLL.resultadoParcial();
                }
                else
                {

                    if (!await _votoUoW.votoBLL.haVotosDia())
                    {
                        response.mensagem = "Nenhum voto registrado";
                        response.sucesso = false;
                        return Ok(response);
                    }

                    if (!await _vencedorUoW.vencedorBLL.vencedorDiaFoiDefinido()) {
                        await _vencedorUoW.vencedorBLL.definirVencedorDia();
                    }

                    response.mensagem = "Resultado final";
                    response.final = await _vencedorUoW.vencedorBLL.getVencedorDia();
                }

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