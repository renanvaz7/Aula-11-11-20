using Projeto_Entity.Controller;
using Projeto_Entity.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto_Entity
{
    public partial class Form1 : Form 
    {
        int Id = 0;
        Produto p = new Produto();

        public Form1()
        {
            InitializeComponent();
            Dados();
        }

        void Dados()
        {
            using (var context = new ProdutoController())
            {
                var produtos = context.AllProdutos();
                dgDados.DataSource = produtos;
            }
        }

        private void ClearDados()
        {
            Id = 0;
            txtNome.Text = "";
            txtCategoria.Text = "";
            txtValorUnitario.Text = "";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtNome.Text != "" && txtValorUnitario.Text != ""  && txtCategoria.Text != "")
            {
                p.Id = Id;
                p.Nome = txtNome.Text;
                p.Valor = decimal.Parse(txtValorUnitario.Text);
                p.Categoria = txtCategoria.Text;

                using (var context = new ProdutoController())
                {
                    context.Add(p);
                    MessageBox.Show("Produtos inseridos com sucesso");
                    Dados();
                    ClearDados();
                }
            }
            else
            {
                MessageBox.Show("Insira os produtos!!!");
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (txtNome.Text != "" && txtValorUnitario.Text != "" && txtCategoria.Text != "")
            {
                using (var context =  new ProdutoController())
                {
                    context.Search(Id);
                    p.Id = Id;
                    p.Nome = txtNome.Text;
                    p.Categoria = txtCategoria.Text;
                    p.Valor = Convert.ToDecimal(txtValorUnitario.Text);
                    context.Edit(p);
                    ClearDados();
                    Dados();
                    MessageBox.Show("Produto editado com sucesso");
                }
            }
            else
            {
                MessageBox.Show("Você não selecionou um produto para editar");
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (txtNome.Text != "" && txtValorUnitario.Text != "" && txtCategoria.Text != "")
            {
                using (var context = new ProdutoController())
                {
                    context.Search(Id);
                    p.Id = Id;
                    context.Remove(p);
                    ClearDados();
                    Dados();
                    MessageBox.Show("Produto removido com sucesso");
                }
            }
            else
            {
                MessageBox.Show("Você não selecionou um produto para excluir");
            }
        }

        private void SelecionarDados(object sender, DataGridViewCellMouseEventArgs e)
        {
            Id = Convert.ToInt32(dgDados.Rows[e.RowIndex].Cells[0].Value.ToString());
            txtNome.Text = dgDados.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtCategoria.Text = dgDados.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtValorUnitario.Text = dgDados.Rows[e.RowIndex].Cells[3].Value.ToString();
        }
    }
}
