using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Projeto1_Loja_de_Roupas.Models;

namespace Projeto1_Loja_de_Roupas.Data
{
    public class Projeto1_Loja_de_RoupasContext : DbContext
    {
        public Projeto1_Loja_de_RoupasContext (DbContextOptions<Projeto1_Loja_de_RoupasContext> options)
            : base(options)
        {
        }

        public DbSet<Projeto1_Loja_de_Roupas.Models.Clientes> Clientes { get; set; }

        public DbSet<Projeto1_Loja_de_Roupas.Models.Tipos> Tipos { get; set; }

        public DbSet<Projeto1_Loja_de_Roupas.Models.Roupas> Roupas { get; set; }

        public DbSet<Projeto1_Loja_de_Roupas.Models.Vendas> Vendas { get; set; }

        public DbSet<Projeto1_Loja_de_Roupas.Models.Rel_Roupas_Vendas> Rel_Roupas_Vendas { get; set; }
    }
}
