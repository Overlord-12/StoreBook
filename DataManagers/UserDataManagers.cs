﻿using BuisnessObjects;
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
    public class UserDataManagers:IUserDataManagers
    {
        private readonly StoreDBContext _storeDBContext;

        public UserDataManagers(StoreDBContext storeDBContext)
        {
            _storeDBContext = storeDBContext;
        }
        public async Task<User> Save(User user)
        {
            try
            {
                _storeDBContext.Add(user);
                await _storeDBContext.SaveChangesAsync();
                return user;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public async Task<bool> Delete(User user)
        {
           _storeDBContext.Remove(user);
            await _storeDBContext.SaveChangesAsync();
            return true;
        }

        public async Task<User> GetById(int id)
        {
            return await _storeDBContext.Users.Include(dto=>dto.Role).FirstOrDefaultAsync(user=>user.Id == id);
        }

        public async Task<List<User>> GetAll()
        {
            return await _storeDBContext.Users.ToListAsync();
        }

        public async Task<User> GetByEmail(string email)
        {
            return await _storeDBContext.Users.Include(dto => dto.Role).FirstOrDefaultAsync(user => user.Name == email);
        }
    }
}
