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
    [Table("product_category", Schema = "public")]
    public class CategoriaProduto
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("description")]
        public string Descricao { get; set; }
        [Column("parent")]
        public int? Parent { get; set; }
        [Column("created_at")]
        public DateTime? DataCriacao { get; set; }
        [Column("updated_at")]
        public DateTime? DataAlteracao { get; set; }
        [Column("deleted_at")]
        public DateTime? DataDelecao { get; set; }
        [JsonIgnore]
        public virtual ICollection<Produto> Produto { get; set; }
    }
}
