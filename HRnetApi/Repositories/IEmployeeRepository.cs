using HRnetApi.Models;

namespace HRnetApi.Repositories
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAllAsync();
        Task<Employee?> GetByIdAsync(int id);
        Task AddEmployeeAsync(Employee employee);
        Task UpdateEmployeeAsync(Employee employee);
        Task DeleteEmployeeAsync(int id);
    }

    //example of an Generic repository, reusable for any tipe of info. Like invoices for example, not only employees.
    //public interface IRepository<T>
    //{
    //    Task<IEnumerable<T>> GetAllAsync();
    //    Task<T> GetByIdAsync(int id);
    //    Task AddAsync(T employee);
    //    Task UpdateAsync(T employee);
    //    Task DeleteAsync(int id);
    //}
}


