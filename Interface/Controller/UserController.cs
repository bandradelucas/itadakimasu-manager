using Domain.ApplicationService;
using Domain.DTO.Customer;
using Infrastructure.Repository;
using Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Http;

namespace BackEnd.Controllers
{
    [RoutePrefix("usuario")]
    public class UserController : ApiController
    {
        UserUnitOfWork uowUser;
        UserApplicationService appUser;

        public UserController()
        {
            uowUser = new UserUnitOfWork();
            appUser = new UserApplicationService();
        }

        [Route("email")]
        [HttpPost]
        public IHttpActionResult PostEmail(UserDTO usuarioDTO)
        {
            using (uowUser)
            {
                try
                {
                    var usuario = uowUser.UserRepository.GetByLoginAndEmail(usuarioDTO.Login, usuarioDTO.Email);
                    appUser.ValidarInfos(usuario);
                    string mailBodyhtml = "<p>Sua senha é:</p>" + usuario.Password;
                    var msg = new MailMessage("projetofatecrp@gmail.com", usuario.Email, "Esqueci a senha!", mailBodyhtml);
                    msg.IsBodyHtml = true;
                    var smtpClient = new SmtpClient("smtp.gmail.com", 587); //if your from email address is "from@hotmail.com" then host should be "smtp.hotmail.com"**
                    smtpClient.UseDefaultCredentials = true;
                    smtpClient.Credentials = new NetworkCredential("projetofatecrp@gmail.com", "projetofatecribeiraopreto");
                    smtpClient.EnableSsl = true;
                    smtpClient.Send(msg);
                    return Ok();

                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }

        [Route("")]
        [HttpPost]
        public IHttpActionResult Post(UserDTO userDTO)
        {
            using (uowUser)
            {
                try
                {
                    var usuarios = uowUser.UserRepository.GetAll();
                    appUser.ValidaUsuarioExiste(usuarios, userDTO);
                    var user = appUser.Post(userDTO);
                    uowUser.UserRepository.Insert(user);
                    uowUser.SaveChanges();
                    return Ok();
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }

        [Route("ValidaUsuario")]
        [HttpPost]
        public IHttpActionResult ValidaUsuario(UserDTO userDTO)
        {
            using (uowUser)
            {
                try
                {
                    var usuario = uowUser.UserRepository.GetByLogin(userDTO.Login);
                    appUser.ValidaLogin(usuario);
                    var dto = appUser.ConverDbToDto(usuario.FirstOrDefault());
                    return Ok(dto);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }

        [Route("{id:int}")]
        [HttpGet]
        public IHttpActionResult GetById(int id)
        {
            using (uowUser)
            {
                try
                {
                    var usuario = uowUser.UserRepository.GetById(id);
                    var dto = appUser.ConverDbToDto(usuario);
                    return Ok(dto);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }


        [Route("getbylogin/{login}")]
        [HttpGet]
        public IHttpActionResult GetByLogin(string login)
        {
            using (uowUser)
            {
                try
                {
                    var usuarios = uowUser.UserRepository.GetByLoginWithContains(login);

                    var list = new List<UserDTO>();
                    foreach (var item in usuarios)
                    {
                        var dto = appUser.ConverDbToDto(item);
                        list.Add(dto);
                    }
                    return Ok(list);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }


        [Route("getall")]
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            using (uowUser)
            {
                try
                {
                    var usuarios = uowUser.UserRepository.GetAll();

                    var list = new List<UserDTO>();
                    foreach (var item in usuarios)
                    {
                        var dto = appUser.ConverDbToDto(item);
                        list.Add(dto);
                    }
                    return Ok(list);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }

        [Route("{id:int}")]
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            using (uowUser)
            {
                try
                {
                    var user = uowUser.UserRepository.GetById(id);
                    uowUser.UserRepository.Delete(user);
                    uowUser.SaveChanges();
                    return Ok();
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }

        [Route("desativar/{id:int}")]
        [HttpPut]
        public IHttpActionResult Desativar(int id)
        {
            using (uowUser)
            {
                try
                {
                    var user = uowUser.UserRepository.GetById(id);
                    appUser.Desativar(user);
                    uowUser.SaveChanges();
                    return Ok();
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }

        [Route("ativar/{id:int}")]
        [HttpPut]
        public IHttpActionResult Ativar(int id)
        {
            using (uowUser)
            {
                try
                {
                    var user = uowUser.UserRepository.GetById(id);
                    appUser.Ativar(user);
                    uowUser.SaveChanges();
                    return Ok();
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }

        [Route("{id:int}")]
        [HttpPut]
        public IHttpActionResult Put(UserDTO userDTO, int id)
        {
            using (uowUser)
            {
                try
                {
                    var usuario = uowUser.UserRepository.GetById(id);
                    appUser.Update(usuario, userDTO);
                    uowUser.SaveChanges();
                    return Ok();
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }
    }
}