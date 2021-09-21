using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjAula16082021.Models
{
    public class Disciplina
    {
        [Key]
        public int Id { get; set; }
        public string Descricao { get; set; }
        public int QtdAlunos { get; set; }
        public string NomeProfessor { get; set; }
    }
}