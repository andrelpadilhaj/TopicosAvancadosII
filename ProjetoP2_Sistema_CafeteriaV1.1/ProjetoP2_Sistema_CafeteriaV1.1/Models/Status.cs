using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoP2_Sistema_CafeteriaV1._1.Models
{
    public class Status
    {
        [Key]
        public int Id { get; set; }
        public string Descricao { get; set; }
    }
}
