using BuisnessObjects;
using BuisnessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManagers.Interface
{
    public interface IEmployeeDataManagers
    {
        Task<Employee> Save(Employee entity);
        Task<bool> Delete(Employee entity);
        Task<Employee> GetById(int id);
        IQueryable<Employee> GetAll();

    }
}
