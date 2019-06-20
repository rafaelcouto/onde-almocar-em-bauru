using OndeAlmocarEmBauru.Entities;
using System.Collections.Generic;

namespace OndeAlmocarEmBauru.Helpers
{
    public class ResultadoVotacaoResponse : ResponseContent
    {
        public IEnumerable<object> parcial;
        public Vencedor final;
    }
}
