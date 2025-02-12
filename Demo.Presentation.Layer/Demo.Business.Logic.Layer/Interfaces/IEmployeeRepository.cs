using Demo.Data.Access.Layer.Models;

namespace Business.Logic.Layer.Interfaces;

public interface IEmployeeRepository : IGenaricRepository<Employee>
{
    public IEnumerable<Employee> GetAll(string address);
    public IEnumerable<Employee> GetAllWithDepartment();

}