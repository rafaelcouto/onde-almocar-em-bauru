using OndeAlmocarEmBauru.BLL.Infra;

namespace OndeAlmocarEmBauru.Api.UoW.Infra
{
    public interface IVotoUoW
    {
        IVotoBLL votoBLL { get; }
    }
}
