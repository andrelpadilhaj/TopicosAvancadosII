using System.ComponentModel.DataAnnotations;

namespace ProjAula30082021.Models
{
    public class Padarias
    {
        #region Properties
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CNPJ { get; set; }
        public string QtdFuncionarios { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        #endregion
    }
}
