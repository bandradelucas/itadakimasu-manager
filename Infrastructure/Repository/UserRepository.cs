using Domain;
using Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class UserRepository
    {
        private DBModel model;

        public User GetById(int id)
        {

            return this.model.User.Where(x => x.Id == id).Include(x => x.Funcao).FirstOrDefault();
        }

        public UserRepository(DBModel model)
        {
            this.model = model;
        }

        public void Insert(User customer)
        {
            this.model.User.Add(customer);
        }

        public List<User> GetAll()
        {
            return this.model.User.Include(x => x.Funcao).ToList();
        }

        public List<User> GetByLogin(string login)
        {
            return this.model.User.Where(x => x.UserName == login).Include(x => x.Funcao).ToList();
        }

        public User GetByLoginAndEmail(string login, string email)
        {
            return this.model.User.Where(x => x.UserName == login && x.Email == email).FirstOrDefault();
        }

        public List<User> GetByLoginWithContains(string login)
        {
            return this.model.User.Where(x => x.UserName.Contains(login)).Include(e => e.Funcao).ToList();
        }

        public void Delete(User produto)
        {
            this.model.User.Remove(produto);
        }
    }
}
