using Demo.Data.Access.Layer.Models;

namespace Business.Logic.Layer.Interfaces;

public interface IEmployeeRepository : IGenaricRepository<Employee>
{
    public IEnumerable<Employee> GetAllByName(string name);
    public IEnumerable<Employee> GetAllWithDepartment();
    
}