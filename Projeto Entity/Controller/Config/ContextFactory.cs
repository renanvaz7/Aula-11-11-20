using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Projeto_Entity.Controller.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Entity.Controller.Config
{
    public class ContextFactory : IDesignTimeDbContextFactory<LojaContext>
    {
        public LojaContext CreateDbContext(string[] args)
        {
            var connectionString = "Server=localhost;Port=3306;Database=loja;Uid=root;Pwd=root";
            var optionsBuilder = new DbContextOptionsBuilder<LojaContext>();
            optionsBuilder.UseMySql(connectionString);
            return new LojaContext(optionsBuilder.Options);
        }
    }
}
