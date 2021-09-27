using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto1_Loja_de_Roupas.Models
{
    public class Rel_Roupas_Vendas
    {
        #region Properties
        [Key]
        public int Id { get; set; }
        public int RoupaId { get; set; }
        public int VendaId { get; set; }
        public int Quantidade { get; set; }

        public virtual Roupas Roupa { get; set; }
        public virtual Vendas Venda { get; set; }
        #endregion
    }
}
