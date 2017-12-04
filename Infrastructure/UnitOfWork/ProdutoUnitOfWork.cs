using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Infrastructure.Model;
using Infrastructure.Repository;

namespace Infrastructure.UnitOfWork
{
    public class ProdutoUnitOfWork : DBModel
    {
        private ProdutoRepository produtoRepository;
        private CategoriaProdutoRepository categoriaProdutoRepository;
        private PedidoRepository pedidoRepository;

        public ProdutoUnitOfWork()
        {
            this.produtoRepository = new ProdutoRepository(this);
            this.pedidoRepository = new PedidoRepository(this);
            this.categoriaProdutoRepository = new CategoriaProdutoRepository(this);
        }


        public ProdutoRepository ProdutoRepository { get { return produtoRepository; } }
        public CategoriaProdutoRepository CategoriaProdutoRepository { get { return categoriaProdutoRepository; } }
        public PedidoRepository PedidoRepository { get { return pedidoRepository; } }

    }
}
