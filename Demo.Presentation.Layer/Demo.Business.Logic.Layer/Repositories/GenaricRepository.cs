using Business.Logic.Layer.Interfaces;
using Demo.Data.Access.Layer.Data;
using Microsoft.EntityFrameworkCore;

namespace Business.Logic.Layer.Repositories;

public class GenaricRepository<TEntity> : IGenaricRepository<TEntity> where TEntity : class
{
    private readonly DataContext _dataContext;
    protected readonly DbSet<TEntity> _dbSet;

    public GenaricRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
        _dbSet = _dataContext.Set<TEntity>();
    }


    public IEnumerable<TEntity> GetAll() => _dbSet.ToList();

    public TEntity? Get(int id) => _dbSet.Find(id);

    public int Create(TEntity entity)
    {
        _dbSet.Add(entity);
        return _dataContext.SaveChanges();
    }

    public int Update(TEntity entity)
    {
        _dbSet.Update(entity);
        return _dataContext.SaveChanges();
    }

    public int Delete(TEntity entity)
    {
        _dbSet.Remove(entity);
        return _dataContext.SaveChanges();
    }
}