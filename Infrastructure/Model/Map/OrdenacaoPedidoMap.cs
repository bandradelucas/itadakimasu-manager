using Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Model.Map
{
    public class OrdenacaoPedidoMap : EntityTypeConfiguration<OrdenacaoPedido>
    {
        public OrdenacaoPedidoMap()
        {
            this
              .HasRequired(x => x.OrdenacaoStatus)
              .WithMany(x => x.OrdenacaoPedido)
              .HasForeignKey(x => x.IdOrdenacaoStatus);
        }
    }
}
