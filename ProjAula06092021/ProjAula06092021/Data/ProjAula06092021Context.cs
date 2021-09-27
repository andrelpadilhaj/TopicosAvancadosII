using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjAula06092021.Models;

namespace ProjAula06092021.Data
{
    public class ProjAula06092021Context : DbContext
    {
        public ProjAula06092021Context (DbContextOptions<ProjAula06092021Context> options)
            : base(options)
        {
        }

        public DbSet<ProjAula06092021.Models.Carros> Carros { get; set; }

        public DbSet<ProjAula06092021.Models.Locacoes> Locacoes { get; set; }
    }
}
