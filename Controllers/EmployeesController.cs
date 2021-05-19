using DemoAngulardotnet.Data;
using DemoAngulardotnet.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DemoAngulardotnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public EmployeesController(ApplicationDBContext context)
        {
            _context = context;
            SeedData();
        }
        private void SeedData()
        {
            if (!_context.Employees.Any())
            {
                _context.Employees.Add(new Employee() { Id = 1, Name = "Jessica Smith", Address = "20 Elm St." });
                _context.Employees.Add(new Employee() { Id = 2, Name = "John Smith", Address = "30 Main St." });
                _context.Employees.Add(new Employee() { Id = 3, Name = "William Johnson", Address = "100 10th St." });
                _context.Employees.Add(new Employee() { Id = 4, Name = "William Johnson", Address = "101 10th St." });
                _context.Employees.Add(new Employee() { Id = 5, Name = "William Johnson", Address = "102 10th St." });
                _context.Employees.Add(new Employee() { Id = 6, Name = "William Johnson", Address = "103 10th St." });
                _context.Employees.Add(new Employee() { Id = 7, Name = "William Johnson", Address = "104 10th St." });
                _context.Employees.Add(new Employee() { Id = 8, Name = "William Johnson", Address = "105 10th St." });
                _context.Employees.Add(new Employee() { Id = 9, Name = "William Johnson", Address = "106 10th St." });
                _context.Employees.Add(new Employee() { Id = 10, Name = "William Johnson", Address = "107 10th St." });
                _context.Employees.Add(new Employee() { Id = 11, Name = "William Johnson", Address = "108 10th St." });
                _context.Employees.Add(new Employee() { Id = 12, Name = "William Johnson", Address = "109 10th St." });
                _context.Employees.Add(new Employee() { Id = 13, Name = "William Johnson", Address = "110 10th St." });
                _context.Employees.Add(new Employee() { Id = 14, Name = "William Johnson", Address = "111 10th St." });
                _context.SaveChanges();
            }
        }
        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees() 
        { 
            return await _context.Employees.ToListAsync(); 
        }


        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return employee;
        }

        // POST api/<ValuesController>
        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployee", new { id = employee.Id }, employee);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(int id, Employee employee)
        {
            if (id != employee.Id)
            {
                return BadRequest();
            }

            _context.Entry(employee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Employee>> Delete(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.Id == id);
        }
    }
}
