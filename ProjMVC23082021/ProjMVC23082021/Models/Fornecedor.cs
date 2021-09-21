using System.ComponentModel.DataAnnotations;

namespace ProjMVC23082021.Models
{
    public class Fornecedor
    {
        #region Properties
        [Key]
        public int Id { get; set; }
        public string NomeFantasia { get; set; }
        public string CNPJ { get; set; }
        #endregion
    }
}
