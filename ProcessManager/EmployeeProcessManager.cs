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
    public class EmployeeProcessManager : IEmployeeProcessManager
    {
        private readonly IEmployeeDataManagers _repository;
        public EmployeeProcessManager(IEmployeeDataManagers repository)
        {
            _repository = repository;
        }
        public Task<bool> Delete(Employee employee)
        {
            return _repository.Delete(employee);
        }

        public Task<Employee> GetEmployeeById(int id)
        {
            return  _repository.GetById(id);
        }

        public Task<Employee> Save(Employee employee)
        {
            return _repository.Save(employee);
        }
    }
}
