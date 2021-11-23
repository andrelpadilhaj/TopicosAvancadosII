using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoP2_Sistema_CafeteriaV1._1.Models
{
    public class Mesas
    {
        [Key]
        public int Id { get; set; }
        public int NumCadeiras { get; set; }
        [ForeignKey("_Status")]
        public int StatusId { get; set; }
        public virtual Status _Status { get; set; }
    }
}
