using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.DTO.Customer;

namespace Domain.ApplicationService
{
    public class UserApplicationService
    {
        public User Post(UserDTO userDTO)
        {
            User user = new User();
            user.Id = userDTO.Id;
            user.UserName = userDTO.Login;
            user.Nome = userDTO.Nome;
            user.Email = userDTO.Email;
            user.Password = userDTO.Senha;
            user.DataNascimento = userDTO.DataNascimento;
            user.CPF = userDTO.CPF;
            user.DataUpdate = null;
            user.DataSave = DateTime.Now;
            user.DataDelete = null;
            user.IdPermissao = userDTO.IdFuncao;
            user.IdFuncao = userDTO.IdFuncao;
            return user;
        }

        public void ValidarInfos(User usuario)
        {
            if (usuario == null)
            {
                throw new Exception("Usuário inválido.");
            }
        }

        public void ValidaUsuarioExiste(List<User> usuarios, UserDTO userDTO)
        {
            usuarios.ForEach(x =>
            {
                if (x.UserName == userDTO.Login)
                    throw new Exception("Usuario já existe.");
            });
        }

        public void ValidaLogin(List<User> usuario)
        {
            if (!usuario.Any())
                throw new Exception("Login ou senha estão errados.");
            if (usuario.FirstOrDefault().DataDelete != null)
                throw new Exception("Este usuário esta destivado.");

        }

        public UserDTO ConverDbToDto(User user)
        {
            return new UserDTO()
            {
                Id = user.Id,
                Login = user.UserName,
                Senha = user.Password,
                Nome = user.Nome,
                CPF = user.CPF,
                Funcao = user.Funcao.Descricao,
                DataNascimento = user.DataNascimento,
                Email = user.Email,
                DataDelete = user.DataDelete,
                IdPermissao = user.IdPermissao
            };
        }

        public void Update(User usuario, UserDTO userDTO)
        {
            if (usuario.Password != userDTO.Senha)
                throw new Exception("A senha está incorreta;");

            usuario.Email = userDTO.Email;
            usuario.CPF = userDTO.CPF;
            usuario.DataNascimento = userDTO.DataNascimento;
            if (!string.IsNullOrEmpty(userDTO.NovaSenha))
                usuario.Password = userDTO.NovaSenha;
            usuario.Nome = userDTO.Nome;
            usuario.DataNascimento = userDTO.DataNascimento;
        }

        public void Desativar(User user)
        {
            user.DataDelete = DateTime.Now;
        }

        public void Ativar(User user)
        {
            user.DataDelete = null;
        }
    }
}
