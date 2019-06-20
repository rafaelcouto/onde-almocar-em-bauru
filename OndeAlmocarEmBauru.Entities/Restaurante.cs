using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OndeAlmocarEmBauru.Entities
{
    [Table("RESTAURANTES")]
    public class Restaurante
    {
        [Key]
        public int RES_ID { get; set; }
        public string RES_NOME { get; set; }
        public string RES_OPCAO { get; set; }
        public string RES_GASTRONOMIA { get; set; }
        public decimal RES_PRECO_MEDIO { get; set; }
    }
}