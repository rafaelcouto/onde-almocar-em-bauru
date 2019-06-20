using OndeAlmocarEmBauru.BLL.Infra;

namespace OndeAlmocarEmBauru.Api.UoW.Infra
{
    public interface IVencedorUoW
    {
        IVencedorBLL vencedorBLL { get; }
    }
}
