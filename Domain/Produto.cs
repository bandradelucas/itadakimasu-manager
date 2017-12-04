using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    [Table("product", Schema = "public")]
    public class Produto
    {

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("description")]
        public string Descricao { get; set; }
        [Column("title")]
        public string Titulo { get; set; }
        [Column("image")]
        public string Imagem { get; set; }
        [Column("categoryid")]
        public int IdCategoria { get; set; }
        [Column("cost")]
        public decimal Custo { get; set; }
        [Column("price")]
        public decimal Preco { get; set; }
        [Column("preparation_time")]
        public TimeSpan TempoPreparacao { get; set; }
        [Column("created_at")]
        public DateTime? DataCriacao { get; set; }
        [Column("updated_at")]
        public DateTime? DataAlteracao { get; set; }
        [Column("deleted_at")]
        public DateTime? DataDelecao { get; set; }
        [JsonIgnore]
        public virtual CategoriaProduto CategoriaProduto { get; set; }
        [JsonIgnore]
        public virtual ICollection<OrdenacaoPedido> OrdenacaoPedido { get; set; }
    }
}
