using Projeto_Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Entity.Controller.Interface
{
    interface IProduto
    {
        void Add(Produto p);
        void Edit(Produto p);
        void Remove(Produto p);
        Produto Search(int id);
        IList<Produto> AllProdutos();
    }
}
