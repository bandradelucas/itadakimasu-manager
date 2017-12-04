using Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Model
{
    public class DBModel : DbContext
    {
        public DBModel()
        : base("name=DBModel")
        {
            //gera os dados necessarios
            Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<User> User { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Icone> Icone { get; set; }
        public DbSet<Permissao> Permisao { get; set; }
        public DbSet<Funcao> Funcao { get; set; }
        public DbSet<CategoriaProduto> CategoriaProduto { get; set; }
        public DbSet<OrdenacaoPedido> OrdenacaoPedido { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.AddFromAssembly(this.GetType().Assembly);
        }

    }
}
