using OndeAlmocarEmBauru.Api.UoW.Infra;
using OndeAlmocarEmBauru.Entities;
using OndeAlmocarEmBauru.Helpers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace OndeAlmocarEmBauru.Api.Controllers
{
    [ApiController]
    public class LoginController : ControllerBase
    {
        private ILoginUoW _loginUoW;

        public LoginController(ILoginUoW loginUoW)
        {
            _loginUoW = loginUoW;
        }

        [Route("api/login"), HttpGet]
        public async Task<IActionResult> GetLogin(string ra, string senha)
        {
            var response = new ResponseContent();
            try
            {
                Aluno aluno = await _loginUoW.alunoBLL.GetLoginAsync(ra, senha);

                if (aluno == null)
                {
                    response.mensagem = "Usuário ou senha inválido";
                    response.sucesso = false;
                }
                else
                {
                    response.mensagem = "Login realizado com sucesso";
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
    }

}