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
    public class PedidoRepository
    {
        private DBModel model;

        public PedidoRepository(DBModel model)
        {
            this.model = model;
        }

        public void Insert(OrdenacaoPedido pedido)
        {
            this.model.OrdenacaoPedido.Add(pedido);
        }

        public List<OrdenacaoPedido> GetAll()
        {
            return this.model.OrdenacaoPedido.Where(x => x.DataDelecao == null).OrderBy(x => x.Id).Include(x => x.Produto).ToList();
        }

        public OrdenacaoPedido GetById(int id)
        {
            return this.model.OrdenacaoPedido.Where(x => x.Id == id).Include(e => e.OrdenacaoStatus).FirstOrDefault();
        }

        public void Delete(OrdenacaoPedido pedido)
        {
            this.model.OrdenacaoPedido.Remove(pedido);
        }
    }
}
