using BCrypt.Net;
using BuisnessObjects;
using DataManagers.Interface;
using ProcessManager.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessManager
{
    public class UserProcessManager : IUserProcessManager
    {
        private readonly IUserDataManagers _repository;
        public UserProcessManager(IUserDataManagers repository)
        {
            _repository = repository;
        }
        public Task<bool> Delete(User user)
        {
            return _repository.Delete(user);
        }
        public Task<User> GetByEmail(string email)
        {
            return _repository.GetByEmail(email);
        }

        public Task<User> GetById(int id)
        {
            return  _repository.GetById(id);
        }

        public Task<List<User>> GetAll()
        {
            return  _repository.GetAll();
        }

        public Task<User> Save(User user)
        {
            return _repository.Save(user);
        }

        public Task<User> Register(User user)
        {
            user.Roleid = 1;
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
            return _repository.Save(user);
        }
    }
}
