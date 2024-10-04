using HRnetApi.Data;
using HRnetApi.Models;
using Microsoft.EntityFrameworkCore;

namespace HRnetApi.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _context;//readonly allows us to asign new values here and in the constructor bellow.
        public EmployeeRepository(AppDbContext context) 
        {
            _context = context;
        }
        public async Task AddEmployeeAsync(Employee employee)
        {
            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();//we mark our employee to be saved to our DBset. Basically the new employee is stored in the context.

        }

        public async Task DeleteEmployeeAsync(int id)
        {
            var employeeInDb = await _context.Employees.FindAsync(id);

            if (employeeInDb == null)
            {
                throw new KeyNotFoundException($"Employee with id {id} was not found.");
            }

            _context.Employees.Remove(employeeInDb);
            await _context.SaveChangesAsync();

        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
           return await _context.Employees.ToListAsync();
        }

        public async Task<Employee?> GetByIdAsync(int id)
        {//with ? we mark that Employee could be nullable. The searched id could not exist. 
            return await _context.Employees.FindAsync(id);
        }

        public async Task UpdateEmployeeAsync(Employee employee)
        {
            _context.Employees.Update(employee);
            await _context.SaveChangesAsync(); //everytime when we change something in the Db we need to save. 
        }
    }
}
