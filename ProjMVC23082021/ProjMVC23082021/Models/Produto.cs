using System.ComponentModel.DataAnnotations;
using System;

namespace ProjMVC23082021.Models
{
    public class Produto
    {
        #region Properties
        [Key]
        public int Id { get; set; }
        [StringLength(100, ErrorMessage = "Não pode ter mais que 100 caracteres.")]
        public string Descricao { get; set; }
        public double Valor { get; set; }
        public DateTime DtCadastro { get; set; }
        #endregion
    }
}
