using OndeAlmocarEmBauru.BLL.Infra;

namespace OndeAlmocarEmBauru.Api.UoW.Infra
{
    public interface ILoginUoW
    {
        IAlunoBLL alunoBLL { get; }
    }
}
