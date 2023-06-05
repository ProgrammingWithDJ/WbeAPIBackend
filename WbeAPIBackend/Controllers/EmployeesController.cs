using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using WbeAPIBackend.Data;
using WbeAPIBackend.Models;

namespace WbeAPIBackend.Controllers
{
    [ApiController]
    [Route("api/employees")]
    public class EmployeesController : Controller
    {
        private readonly FullstackDbContext _fullstackDbContext;

        public EmployeesController(FullstackDbContext fullstackDbContext)
        {
            _fullstackDbContext = fullstackDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            var employees = await _fullstackDbContext.Employees.ToListAsync();

            return Ok(employees);
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee([FromBody] Employee employeerequest)
        {

            employeerequest.Id = new Guid();

            await _fullstackDbContext.Employees.AddAsync(employeerequest);
            await _fullstackDbContext.SaveChangesAsync();

            return Ok(employeerequest);
        }

        [HttpGet]
        [Route("{Id:Guid}")]
        public async Task<IActionResult> GetEmployeeByID([FromRoute] Guid Id)
        {
            var employees = await _fullstackDbContext.Employees.FirstOrDefaultAsync(x => x.Id == Id);

            if (employees == null)
            {
                return NotFound();
            }

            return Ok(employees);

        }

        [HttpPut]
        [Route("{Id:Guid}")]
        public async Task<IActionResult> UpdateEmployee([FromRoute] Guid Id,    Employee Updateemployee)
        {

            var employees = await _fullstackDbContext.Employees.FirstOrDefaultAsync(x => x.Id == Updateemployee.Id);

            if (employees == null)
            {
                return NotFound();
            }

            employees.Name = Updateemployee.Name;
            employees.Phone = Updateemployee.Phone;
            employees.Salary = Updateemployee.Salary;
            employees.Department = Updateemployee.Department;
            employees.Email = Updateemployee.Email;

            await _fullstackDbContext.SaveChangesAsync();

            return Ok(employees);
        }
    }
    }
