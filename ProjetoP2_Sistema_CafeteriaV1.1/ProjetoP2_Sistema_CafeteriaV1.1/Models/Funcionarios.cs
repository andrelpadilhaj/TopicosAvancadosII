using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoP2_Sistema_CafeteriaV1._1.Models
{
    public class Funcionarios
    {
        [Key]
        public int Id { get; set; }
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        
        [NotMapped]
        public virtual Telefones _Telefone { get; set; }
        [NotMapped]
        public virtual List<Telefones> _ListTelefones { get; set; }
    }
}
