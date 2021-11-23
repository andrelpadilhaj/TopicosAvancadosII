using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoP2_Sistema_CafeteriaV1._1.Models
{
    public class Telefones
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Funcionario")]
        public int FuncionarioId { get; set; }
        public string NumTelefone { get; set; }
        public string Descricao { get; set; }

        public virtual Funcionarios Funcionario { get; set; }
    }
}
