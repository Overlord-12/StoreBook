using BusinessObjects;
using DataManagers.Interface;
using ProcessManager.Interface;

namespace ProcessManager
{
    public class UserProcessManager : IUserProcessManager
    {
        private readonly IUserDataManagers _repository;
        public UserProcessManager(IUserDataManagers repository)
        {
            _repository = repository;
        }
        public async Task<bool> Delete(User user)
        {
            return await _repository.Delete(user);
        }
        public async Task<User> GetByEmail(string email)
        {
            return await _repository.GetByEmail(email);
        }

        public async Task<User> GetById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task<List<User>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<User> Save(User user)
        {
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
            return await _repository.Save(user);
        }

        public async Task<User> Register(User user)
        {
            user.Roleid = 1;
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
            return await _repository.Save(user);
        }

        public async Task<User> GetUserByCred(string email, string password)
        {
            var user = await _repository.GetByEmail(email);
            bool isPasswordSingular = BCrypt.Net.BCrypt.Verify(password, user?.Password);

            if (user == null || !isPasswordSingular)
                return null;

            return user;
        }
    }
}
