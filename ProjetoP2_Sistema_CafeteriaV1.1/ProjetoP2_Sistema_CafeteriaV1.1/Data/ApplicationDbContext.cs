using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjetoP2_Sistema_CafeteriaV1._1.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoP2_Sistema_CafeteriaV1._1.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Funcionarios> _DBFuncionarios { get; set; }
        public DbSet<Telefones> _DBTelefones { get; set; }
        public DbSet<Status> _DBStatus { get; set; }
        public DbSet<Mesas> _DBMesas { get; set; }
        public DbSet<Produtos> _DBProdutos { get; set; }
        public DbSet<Pedidos> _DBPedidos { get; set; }
        public DbSet<RelPedidosProdutos> _DBRelPedidosProdutos { get; set; }
    }
}
