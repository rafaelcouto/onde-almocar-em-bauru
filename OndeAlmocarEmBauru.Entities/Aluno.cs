using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OndeAlmocarEmBauru.Entities
{
    [Table("ALUNOS")]
    public class Aluno
    {
        [Key]
        public string ALU_RA { get; set; }
        public string ALU_NOME { get; set; }
        public string ALU_SENHA { get; set; }
    }
}
