using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ProjMVC23082021.Models;

namespace ProjMVC23082021.Data
{
    public class ProjMVC23082021Context : DbContext
    {
        public ProjMVC23082021Context (DbContextOptions<ProjMVC23082021Context> options)
            : base(options)
        {
        }
        public DbSet<ProjMVC23082021.Models.Produto> Produtos { get; set; }

        public DbSet<ProjMVC23082021.Models.Funcionario> Funcionarios { get; set; }

        public DbSet<ProjMVC23082021.Models.Fornecedor> Fornecedores { get; set; }
    }
}
