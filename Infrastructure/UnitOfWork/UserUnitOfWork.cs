using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Infrastructure.Model;
using Infrastructure.Repository;

namespace Infrastructure.UnitOfWork
{
    public class UserUnitOfWork : DBModel
    {
        private UserRepository userRepository;

        public UserUnitOfWork()
        {
            this.userRepository = new UserRepository(this);
        }


        public UserRepository UserRepository { get { return userRepository; } }

    }
}
