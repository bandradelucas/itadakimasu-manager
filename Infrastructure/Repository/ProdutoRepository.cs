using Domain;
using Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class ProdutoRepository
    {
        private DBModel model;

        public Produto GetById(int id)
        {

            return this.model.Produto.Where(x => x.Id == id).Include(x => x.CategoriaProduto).FirstOrDefault();
        }

        public ProdutoRepository(DBModel model)
        {
            this.model = model;
        }

        public void Insert(Produto produto)
        {
            this.model.Produto.Add(produto);
        }

        public List<Produto> GetAll()
        {
            return this.model.Produto.Include(x => x.CategoriaProduto).ToList();
        }

        public List<Produto> GetByDescricao(string descricao)
        {
            return this.model.Produto.Where(x => x.Descricao.Contains(descricao)).Include(x => x. CategoriaProduto).ToList();
        }

        public void Delete(Produto produto)
        {
            this.model.Produto.Remove(produto);
        }
    }
}
