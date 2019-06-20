using OndeAlmocarEmBauru.Api.UoW.Infra;
using OndeAlmocarEmBauru.BLL.Infra;

namespace OndeAlmocarEmBauru.Api.UoW
{
    public class VencedorUoW : IVencedorUoW
    {
        public IVencedorBLL vencedorBLL { get; }

        public VencedorUoW(IVencedorBLL vencedorBLL)
        {
            this.vencedorBLL = vencedorBLL;
        }
    }
}
