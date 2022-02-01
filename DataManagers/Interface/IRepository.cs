using BuisnessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManagers.Interface
{
    public interface IRepository
    {
        Task<T> Save<T>(T entity)where T: SqlEntityBase;
        Task<bool> Delete<T>(T entity) where T : SqlEntityBase;
        Task<T> GetById<T>(int id) where T : SqlEntityBase;

    }
}
