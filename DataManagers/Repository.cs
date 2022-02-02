using BuisnessObjects;
using BuisnessObjects.Models;
using DataManagers.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManagers
{
    public class Repository:IRepository
    {
        private readonly StoreDBContext _storeDBContext;

        public Repository(StoreDBContext storeDBContext)
        {
            _storeDBContext = storeDBContext;
        }
        public async Task<T> Save<T>(T entity)where T : SqlEntityBase
        {
            _storeDBContext.Add<T>(entity);
            await _storeDBContext.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> Delete<T>(T entity) where T:SqlEntityBase
        {
           _storeDBContext.Remove<T>(entity);
            await _storeDBContext.SaveChangesAsync();
            return true;
        }

        public async Task<T> GetById<T>(int id) where T : SqlEntityBase
        {
            return await _storeDBContext.FindAsync<T>(id);
        }
    }
}
