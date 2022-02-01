using BuisnessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessManager.Interface
{
    public interface IEmployeeProcessManager
    {
        public Task<Employee> Save(Employee employee);
        public Task<bool> Delete(Employee employee);
        public Task<Employee> GetEmployeeById(int id);
    }
}
