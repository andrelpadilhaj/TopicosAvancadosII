using System.ComponentModel.DataAnnotations;

namespace Projeto1_Loja_de_Roupas.Models
{
    public class Tipos
    {
        #region Properties
        [Key]
        public int Id { get; set; }
        [MaxLength(100)]
        public string Descricao { get; set; }
        public double Valor { get; set; }
        #endregion
    }
}
