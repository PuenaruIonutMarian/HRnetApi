using Microsoft.AspNetCore.Mvc;
using HRnetApi.Models;
using HRnetApi.Repositories;




namespace HRnetApi.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeesRepository;

        public EmployeeController(IEmployeeRepository employeesRepository)
        {
            _employeesRepository = employeesRepository;
        }

        [HttpGet]
        //here there are so many types because task, actionresult and ienumerable are all generics
        public async Task<ActionResult<IEnumerable<Employee>>> GetAllEmployeesAsync()
        {
            var allEmployees = await _employeesRepository.GetAllAsync();
            return Ok(allEmployees);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployeeById(int id)
        {
            var employee = await _employeesRepository.GetByIdAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> CreateEmployee(Employee employee)
        {
            //modelstate check if our model employee passes all the data adnotations
            if (ModelState.IsValid == false)
            {
                return BadRequest();
            }
            await _employeesRepository.AddEmployeeAsync(employee);
            // in the response you will get the path and id of the new created employee (see swagger response headers)
            return CreatedAtAction(nameof(GetEmployeeById), new { id = employee.ID }, employee);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEmployeeById(int id)
        {
            await _employeesRepository.DeleteEmployeeAsync(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Employee>> UpdateEmployeeAsync(int id, Employee employee)
        {
            if (id != employee.ID)
            {
                return BadRequest();
            }
            if (ModelState.IsValid == false)
            {
                return BadRequest();
            }
            await _employeesRepository.UpdateEmployeeAsync(employee);

            return CreatedAtAction(nameof(GetEmployeeById), new { id = employee.ID }, employee);

        }
    }
}
