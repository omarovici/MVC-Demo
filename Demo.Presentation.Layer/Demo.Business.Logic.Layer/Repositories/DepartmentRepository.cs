using Business.Logic.Layer.Interfaces;
using Demo.Data.Access.Layer.Data;
using Demo.Data.Access.Layer.Models;

namespace Business.Logic.Layer.Repositories;

public class DepartmentRepository : GenaricRepository<Department>, IDepartmentRepository
{
    public DepartmentRepository(DataContext dataContext) : base(dataContext)
    {
    }
}