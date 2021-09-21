using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace UnipPim.Hotel.Dominio.Interfaces
{
    public interface IRepositorioBase<T> : IDisposable where T : IAggregateRoot
    {
        Task Insert(T entity);              
        Task Update(T entity);
        Task Delete(T entity);
        Task<T> ObterPorId(Guid id);
        Task<T> Find(Expression<Func<T, bool>> predicate);
        Task<int> SaveChanges();
    }
}
