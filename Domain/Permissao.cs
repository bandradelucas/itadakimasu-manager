using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Table("permission", Schema = "public")]
    public class Permissao
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("created_at")]
        public DateTime? DataSave { get; set; }
        [Column("deleted_at")]
        public DateTime? DataDelete { get; set; }
        [JsonIgnore]
        public virtual ICollection<User> Usuario { get; set; }

    }
}
