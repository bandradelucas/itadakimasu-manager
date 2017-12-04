using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Table("usuario", Schema = "public")]
    public class User
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("functionid")]
        [Required]
        public int IdFuncao { get; set; }
        [Column("permissionid")]
        [Required]
        public int IdPermissao { get; set; }
        [Column("username")]
        public string UserName { get; set; }
        [Column("name")]
        public string Nome { get; set; }
        [Column("cpf")]
        public string CPF { get; set; }
        [Column("email")]
        public string Email { get; set; }
        [Column("password")]
        public string Password { get; set; }
        [Column("birthdaydate")]
        public DateTime DataNascimento { get; set; }
        [Column("created_at")]
        public DateTime? DataSave { get; set; }
        [Column("updated_at")]
        public DateTime? DataUpdate { get; set; }
        [Column("deleted_at")]
        public DateTime? DataDelete { get; set; }
        [JsonIgnore]
        public virtual Funcao Funcao { get; set; }
        [JsonIgnore]
        public virtual Permissao Permissao { get; set; }
    }
}
