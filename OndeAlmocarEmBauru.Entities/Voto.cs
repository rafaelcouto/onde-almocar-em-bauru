using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OndeAlmocarEmBauru.Entities
{
    [Table("VOTOS")]
    public class Voto
    {
        [Key]
        public int VOT_ID { get; set; }
        public string ALU_RA { get; set; }

        public DateTime VOT_DATA { get; set; }

        [ForeignKey("Restaurante")]
        public int RES_ID { get; set; }

        public virtual Restaurante Restaurante { get; set; }
    }
}