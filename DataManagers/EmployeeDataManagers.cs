using BuisnessObjects;
using BuisnessObjects.Models;
using DataManagers.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManagers
{
    public class EmployeeDataManagers:IEmployeeDataManagers
    {
        private readonly StoreDBContext _storeDBContext;

        public EmployeeDataManagers(StoreDBContext storeDBContext)
        {
            _storeDBContext = storeDBContext;
        }
        public async Task<Employee> Save(Employee entity)
        {
            _storeDBContext.Add(entity);
            await _storeDBContext.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> Delete(Employee entity)
        {
           _storeDBContext.Remove(entity);
            await _storeDBContext.SaveChangesAsync();
            return true;
        }

        public async Task<Employee> GetById(int id)
        {
            return await _storeDBContext.Employees.FindAsync(id);
        }

        public IQueryable<Employee> GetAll()
        {
            var test = _storeDBContext.Employees;
            return test;
        }
    }
}
