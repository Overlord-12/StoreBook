using BuisnessObjects;
using BuisnessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManagers.Interface
{
    public interface IUserDataManagers
    {
        Task<User> Save(User user);
        Task<bool> Delete(User user);
        Task<User> GetById(int id);
        Task<User> GetByEmail(string email);
        Task<List<User>> GetAll();

    }
}
