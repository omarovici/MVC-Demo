namespace Business.Logic.Layer.Interfaces;

public interface IUnitOfWork
{
    public IEmployeeRepository Employees { get; }
    public IDepartmentRepository Departments { get; }
    public int SaveChanges();
}