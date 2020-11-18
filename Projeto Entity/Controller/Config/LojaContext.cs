using Microsoft.EntityFrameworkCore;
using Projeto_Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Entity.Controller.Mapping
{
    public class LojaContext : DbContext
    {
        public DbSet<Produto> Produtos { get; set; }
        public LojaContext(DbContextOptions<LojaContext> options) : base(options) { }

        public LojaContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Produto>(new ProdutoMap().Configure);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("Server=localhost;Port=3306;Database=loja;Uid=root;Pwd=root");
        }
    }
}
