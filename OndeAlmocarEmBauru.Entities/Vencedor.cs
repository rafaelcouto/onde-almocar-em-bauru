using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OndeAlmocarEmBauru.Entities
{
    [Table("VENCEDORES")]
    public class Vencedor
    {
        [Key]
        public int VCD_ID { get; set; }
        public DateTime VCD_DATA { get; set; }

        [ForeignKey("Restaurante")]
        public int RES_ID { get; set; }

        public virtual Restaurante Restaurante { get; set; }
    }
}