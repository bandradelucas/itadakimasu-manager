using Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Model.Map
{
    public class ProdutoMap : EntityTypeConfiguration<Produto>
    {
        public ProdutoMap()
        {
            this
                .HasRequired(x => x.CategoriaProduto)
                .WithMany(x => x.Produto)
                .HasForeignKey(x => x.IdCategoria);

            this
                .HasMany(x => x.OrdenacaoPedido)
                .WithRequired(x => x.Produto)
                .HasForeignKey(x => x.IdProduto);
        }
    }
}
