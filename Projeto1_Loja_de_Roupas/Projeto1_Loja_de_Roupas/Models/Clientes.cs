using System;
using System.ComponentModel.DataAnnotations;

namespace Projeto1_Loja_de_Roupas.Models
{
    public class Clientes
    {
        #region Properties
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        public string Nome { get; set; }
        [MaxLength(16)]
        public string Telefone { get; set; }
        public DateTime Nascimento { get; set; }
        [MaxLength(14)]
        public string CPF { get; set; }
        [MaxLength(100)]
        public string Endereco { get; set; }
        #endregion
    }
}
