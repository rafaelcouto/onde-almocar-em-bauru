using OndeAlmocarEmBauru.Api.UoW.Infra;
using OndeAlmocarEmBauru.BLL.Infra;

namespace OndeAlmocarEmBauru.Api.UoW
{
    public class LoginUoW : ILoginUoW
    {
        public IAlunoBLL alunoBLL { get; }

        public LoginUoW(IAlunoBLL loginBLL)
        {
            this.alunoBLL = loginBLL;
        }
    }
}
