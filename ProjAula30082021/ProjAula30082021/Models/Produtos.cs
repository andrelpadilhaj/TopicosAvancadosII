using System;
using System.ComponentModel.DataAnnotations;

namespace ProjAula30082021.Models
{
    public class Produtos
    {
        #region Properties
        [Key]
        public int Id { get; set; }
        public string Descricao { get; set; }
        public DateTime Validade { get; set; }
        #endregion
    }
}
