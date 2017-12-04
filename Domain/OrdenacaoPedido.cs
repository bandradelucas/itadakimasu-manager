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
    [Table("ordination", Schema = "public")]
    public class OrdenacaoPedido
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("userid")]
        public string UserId { get; set; }
        [Column("amount")]
        public int Quantidade { get; set; }
        [Column("request")]
        public string Requisicao { get; set; }
        [Column("orderstatusid")]
        public int IdOrdenacaoStatus { get; set; }
        [Column("created_at")]
        public DateTime? DataCriacao { get; set; }
        [Column("updated_at")]
        public DateTime? DataAlteracao { get; set; }
        [Column("deleted_at")]
        public DateTime? DataDelecao { get; set; }
        [Column("productid")]
        public int IdProduto { get; internal set; }
        [JsonIgnore]
        public virtual Produto Produto { get; set; }
        [JsonIgnore]
        public virtual OrdenacaoStatus OrdenacaoStatus { get; set; }
    }
}
