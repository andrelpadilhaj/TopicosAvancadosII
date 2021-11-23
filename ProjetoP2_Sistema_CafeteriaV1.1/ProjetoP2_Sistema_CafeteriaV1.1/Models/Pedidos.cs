using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoP2_Sistema_CafeteriaV1._1.Models
{
    public class Pedidos
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("_Mesa")]
        public int MesaId { get; set; }
        [ForeignKey("_Funcionario")]
        public int FuncionarioId { get; set; }
        public DateTime DataHoraAbertura { get; set; }
        public DateTime? DataHoraFechamento { get; set; }
        public double Total { get; set; }

        public virtual Mesas _Mesa { get; set; }
        public virtual Funcionarios _Funcionario { get; set; }

        [NotMapped]
        public virtual List<SelectListItem> _SelectMesa { get; set; }
        [NotMapped]
        public virtual List<SelectListItem> _SelectFuncionario { get; set; }
        [NotMapped]
        public virtual RelPedidosProdutos _PedidosProdutos { get; set; }
        [NotMapped]
        public virtual List<RelPedidosProdutos> _ListPedidosProdutos { get; set; }
    }
}
