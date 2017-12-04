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
    [Table("icon_details", Schema = "public")]
    public class Icone
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("slug")]
        public string Slug { get; set; }
        [Column("create_at")]
        public DateTime? DataCriacao { get; set; }
        [Column("update_at")]
        public DateTime? DataAlteracao { get; set; }
        [Column("delete_at")]
        public DateTime? DataDelecao { get; set; }
    }
}
