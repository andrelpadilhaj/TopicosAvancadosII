using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto1_Loja_de_Roupas.Models
{
    public class Roupas
    {
        #region Properties
        [Key]
        public int Id { get; set; }
        [MaxLength(20)]
        public string Cor { get; set; }
        public int Quantidade { get; set; }
        public virtual Tipos Tipo { get; set; }
        [NotMapped]
        public virtual List<SelectListItem> Tipos { get; set; }
        #endregion
    }
}
