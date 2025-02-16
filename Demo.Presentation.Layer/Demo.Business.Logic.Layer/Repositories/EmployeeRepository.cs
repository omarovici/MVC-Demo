using Business.Logic.Layer.Interfaces;
using Demo.Data.Access.Layer.Data;
using Demo.Data.Access.Layer.Models;
using Microsoft.EntityFrameworkCore;

namespace Business.Logic.Layer.Repositories;

public class EmployeeRepository : GenaricRepository<Employee>, IEmployeeRepository
{
    public EmployeeRepository(DataContext dataContext) : base(dataContext)
    {
    }
    public IEnumerable<Employee> GetAllByName(string name)
    => _dbSet.Where(e => e.Name.ToLower().Contains(name.ToLower())).Include(e => e.Department).ToList();

    public IEnumerable<Employee> GetAllWithDepartment()
    => _dbSet.Include(e => e.Department).ToList();
}