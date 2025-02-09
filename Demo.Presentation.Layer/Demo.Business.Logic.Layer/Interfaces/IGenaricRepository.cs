namespace Business.Logic.Layer.Interfaces;

public interface IGenaricRepository<TEntity> where TEntity : class
{
    IEnumerable<TEntity> GetAll();
    TEntity? Get(int id);
    int Create(TEntity entity);
    int Update(TEntity entity);
    int Delete(TEntity entity);
}