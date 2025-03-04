namespace Business.Logic.Layer.Interfaces;

public interface IGenaricRepository<TEntity> where TEntity : class
{
    IEnumerable<TEntity> GetAll();
    TEntity? Get(int id);
    void Create(TEntity entity);
    void Update(TEntity entity);
    void Delete(TEntity entity);
}