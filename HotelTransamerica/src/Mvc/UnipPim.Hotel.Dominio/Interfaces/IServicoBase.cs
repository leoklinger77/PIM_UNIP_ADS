using System;
using System.Threading.Tasks;

namespace UnipPim.Hotel.Dominio.Interfaces
{
    public interface IServicoBase<T> : IDisposable where T : IAggregateRoot
    {
        Task Insert(T entity);              
        Task Update(T entity);
        Task Delete(Guid id);
        Task<T> ObterPorId(Guid id);
    }
}
