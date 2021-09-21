using System.ComponentModel.DataAnnotations;
using System;

namespace ProjMVC23082021.Models
{
    public class Produto
    {
        #region Properties
        [Key]
        public int Id { get; set; }
        public string Descricao { get; set; }
        public double Valor { get; set; }
        public DateTime DtCadastro { get; set; }
        #endregion
    }
}
