#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BuisnessObjects;
using ProcessManager.Interface;
using StoreBookWebApi.Models.Employee;
using AutoMapper;

namespace StoreBookWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserProcessManager _userProcessManager;
        public readonly IMapper _mapper; 
        public readonly StoreDBContext storeDBContext;

        public UserController(IUserProcessManager userProcessManager, IMapper mapper)
        {
            _mapper = mapper;
            _userProcessManager = userProcessManager;
        }

        // GET: api/Employees
        [HttpGet("getUsers")]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _userProcessManager.GetAll();
        }

        // GET: api/Employees/5
        [HttpGet("getUserById")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var employee = await _userProcessManager.GetById(id);

            if (employee == null)
            {
                return NotFound();
            }

            return employee;
        }
       
        [HttpPost("saveUser")]
        public async Task<ActionResult<User>> SaveUser(UserDto user)
        {
           var result = await _userProcessManager.Save(_mapper.Map<User>(user));

            return Ok(result);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteUserById(int id)
        {
            var currentUser = await _userProcessManager.GetById(id);
            var result =await _userProcessManager.Delete(currentUser);

            return Ok(result);
        }

    }
}
