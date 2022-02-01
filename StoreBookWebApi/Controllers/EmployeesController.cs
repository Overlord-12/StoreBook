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

namespace StoreBookWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly StoreDBContext _context;
        private readonly IEmployeeProcessManager _employeeProcessManager;

        public EmployeesController(StoreDBContext context, IEmployeeProcessManager employeeProcessManager)
        {
            _context = context;
            _employeeProcessManager = employeeProcessManager;
        }

        // GET: api/Employees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            return await _context.Employees.ToListAsync();
        }

        // GET: api/Employees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            var employee = await _employeeProcessManager.GetEmployeeById(id);

            if (employee == null)
            {
                return NotFound();
            }

            return employee;
        }

       
        [HttpPost]
        public async Task<ActionResult<Employee>> SaveEmployee(Employee employee)
        {
           var result = await _employeeProcessManager.Save(employee);

            return Ok(result);
        }

    }
}
