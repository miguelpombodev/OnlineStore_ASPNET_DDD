namespace OnlineStore.Domain.Interfaces.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity GetById(Guid id);
    }
}