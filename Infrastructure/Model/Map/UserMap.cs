using Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Model.Map
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            this
                .HasRequired(x => x.Funcao)
                .WithMany(x => x.Usuario)
                .HasForeignKey(x => x.IdFuncao);

            this
                .HasRequired(x => x.Permissao)
                .WithMany(x => x.Usuario)
                .HasForeignKey(x => x.IdPermissao);
        }
    }
}
