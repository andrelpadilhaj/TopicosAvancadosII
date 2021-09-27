using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjAula06092021.Models
{
    public class Locacoes
    {
        #region Properties
        [Key]
        public int Id { get; set; }
        public string Descricao { get; set; }
        public virtual Carros Carro { get; set; }

        [NotMapped]
        public virtual List<SelectListItem> Carros { get; set; }
        #endregion
    }
}
