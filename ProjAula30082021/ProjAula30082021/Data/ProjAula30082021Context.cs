using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjAula30082021.Models;

namespace ProjAula30082021.Data
{
    public class ProjAula30082021Context : DbContext
    {
        public ProjAula30082021Context (DbContextOptions<ProjAula30082021Context> options)
            : base(options)
        {
        }

        public DbSet<ProjAula30082021.Models.Clientes> Clientes { get; set; }

        public DbSet<ProjAula30082021.Models.Padarias> Padarias { get; set; }

        public DbSet<ProjAula30082021.Models.Produtos> Produtos { get; set; }
    }
}
