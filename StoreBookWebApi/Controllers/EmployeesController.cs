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
    public class EmployeesController : ControllerBase
    {
        private readonly StoreDBContext _context;
        private readonly IEmployeeProcessManager _employeeProcessManager;
        public readonly IMapper _mapper; 

        public EmployeesController(StoreDBContext context, IEmployeeProcessManager employeeProcessManager, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
            _employeeProcessManager = employeeProcessManager;
        }

        // GET: api/Employees
        [HttpGet("getEmployees")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            return await _context.Employees.ToListAsync();
        }

        // GET: api/Employees/5
        [HttpGet("getEmployeeById")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            var employee = await _employeeProcessManager.GetEmployeeById(id);

            if (employee == null)
            {
                return NotFound();
            }

            return employee;
        }
       
        [HttpPost("saveEmployee")]
        public async Task<ActionResult<Employee>> SaveEmployee(EmployeeDto employee)
        {
           var result = await _employeeProcessManager.Save(_mapper.Map<Employee>(employee));

            return Ok(result);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteEmployee(EmployeeDto employee)
        {
            var result =await _employeeProcessManager.Delete(_mapper.Map<Employee>(employee));

            return Ok(result);
        }

    }
}
