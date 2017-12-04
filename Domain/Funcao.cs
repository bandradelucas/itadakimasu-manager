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
    [Table("function", Schema = "public")]
    public class Funcao
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("description")]
        public string Descricao { get; set; }
        [Column("created_at")]
        public DateTime? DataSave { get; set; }
        [Column("updated_at")]
        public DateTime? DataUpdate { get; set; }

        [JsonIgnore]
        public virtual ICollection<User> Usuario { get; set; }
    }
}
