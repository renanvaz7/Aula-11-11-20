using Projeto_Entity.Controller.Interface;
using Projeto_Entity.Controller.Mapping;
using Projeto_Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Entity.Controller
{
    public class ProdutoController : IProduto, IDisposable
    {
        private LojaContext context;
        
        public ProdutoController()
        {
            this.context = new LojaContext();
        }

        public void Add(Produto p)
        {
            context.Produtos.Add(p);
            context.SaveChanges();
        }

        public IList<Produto> AllProdutos()
        {
            return context.Produtos.ToList();
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public void Edit(Produto p)
        {
            var originalData = this.Search(p.Id);
            this.context.Entry(originalData).CurrentValues.SetValues(p);
            context.SaveChanges();
        }

        public void Remove(Produto p)
        {
            var originalData = this.Search(p.Id);
            this.context.Remove(originalData);
            context.SaveChanges();
        }

        public Produto Search(int id)
        {
            return context.Produtos.Find(id);
        }
    }
}
