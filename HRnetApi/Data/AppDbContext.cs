using HRnetApi.Models;
using Microsoft.EntityFrameworkCore;

namespace HRnetApi.Data
{
    public class AppDbContext : DbContext
    {

        public DbSet<Employee> Employees { get; set; } //inside a context we need to specify which type of data we want to store

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        { }

    }
}