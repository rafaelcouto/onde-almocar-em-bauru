using OndeAlmocarEmBauru.Api.UoW.Infra;
using OndeAlmocarEmBauru.BLL.Infra;

namespace OndeAlmocarEmBauru.Api.UoW
{
    public class VotoUoW : IVotoUoW
    {
        public IVotoBLL votoBLL { get; }

        public VotoUoW(IVotoBLL votoBLL)
        {
            this.votoBLL = votoBLL;
        }
    }
}
