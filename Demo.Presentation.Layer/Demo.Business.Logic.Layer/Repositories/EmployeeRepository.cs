using Business.Logic.Layer.Interfaces;
using Demo.Data.Access.Layer.Data;
using Demo.Data.Access.Layer.Models;

namespace Business.Logic.Layer.Repositories;

public class EmployeeRepository : GenaricRepository<Employee>, IEmployeeRepository
{
    public EmployeeRepository(DataContext dataContext) : base(dataContext)
    {
    }
    public IEnumerable<Employee> GetAll(string address)
    => _dbSet.Where(e => e.Address.ToLower() == address.ToLower()).ToList();
}