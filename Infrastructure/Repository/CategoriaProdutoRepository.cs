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
    public class CategoriaProdutoRepository
    {
        private DBModel model;

        public CategoriaProdutoRepository(DBModel model)
        {
            this.model = model;
        }

        public CategoriaProduto GetById(int id)
        {
            return this.model.CategoriaProduto.Where(x => x.Id == id).FirstOrDefault();
        }
    }
}
