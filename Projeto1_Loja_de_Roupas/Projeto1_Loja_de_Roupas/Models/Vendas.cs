using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto1_Loja_de_Roupas.Models
{
    public class Vendas
    {
        #region Properties
        [Key]
        public int Id { get; set; }
        public double Valor { get; set; }
        public DateTime Data { get; set; }
        public virtual Clientes Cliente { get; set; }
        [NotMapped]
        public virtual List<SelectListItem> Clientes { get; set; }
        #endregion
    }
}
