using System;
using System.ComponentModel.DataAnnotations;

namespace ProjAula06092021.Models
{
    public class Carros
    {
        #region Properties
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cor { get; set; }
        public int Ano { get; set; }
        public int Modelo { get; set; }
        public string Placa { get; set; }
        #endregion
    }
}
