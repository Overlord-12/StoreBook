using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessManager.Interface
{
    public interface IUserProcessManager
    {
        Task<User> Save(User user);
        Task<User> Register(User user);
        Task<User> GetByEmail(string email);
        Task<bool> Delete(User user);
        Task<User> GetById(int id);
        Task<List<User>> GetAll();
        Task<User> GetUserByCred(string email, string password);
    }
}
