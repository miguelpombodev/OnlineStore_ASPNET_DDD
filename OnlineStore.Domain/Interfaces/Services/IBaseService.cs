using OnlineStore.Domain.Models;

namespace OnlineStore.Domain.Interfaces.Services
{
    public interface IBaseService<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> GetById(Guid id);
    }
}