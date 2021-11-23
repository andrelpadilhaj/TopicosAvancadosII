using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoP2_Sistema_CafeteriaV1._1.Models
{
    public class RelPedidosProdutos
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("_Pedido")]
        public int PedidoId { get; set; }
        [ForeignKey("_Produto")]
        public int ProdutoId { get; set; }
        public int Quantidade { get; set; }

        public virtual Pedidos _Pedido { get; set; }
        public virtual Produtos _Produto { get; set; }

        [NotMapped]
        public virtual List<SelectListItem> _SelectProduto { get; set; }
    }
}
