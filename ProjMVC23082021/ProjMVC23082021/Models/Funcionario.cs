using System.ComponentModel.DataAnnotations;

namespace ProjMVC23082021.Models
{
    public class Funcionario
    {
        #region Properties
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
        #endregion
    }
}
