using System;
using System.ComponentModel.DataAnnotations;

namespace ProjAula30082021.Models
{
    public class Clientes
    {
        #region Properties
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        #endregion
    }
}
