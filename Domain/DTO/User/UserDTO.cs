using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO.Customer
{
    public class UserDTO
    {
        public string Email { get; set; }
        public int Id { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string NovaSenha { get; set; }
        public string Nome { get; set; }
        public int IdFuncao { get; set; }
        public DateTime DataSave { get; set; }
        public DateTime DataUpdate { get; set; }
        public DateTime? DataDelete { get; set; }
        public DateTime DataNascimento { get; set; }
        public string CPF { get; set; }
        public int IdPermissao { get; set; }
        public string Funcao { get; set; }
    }
}
