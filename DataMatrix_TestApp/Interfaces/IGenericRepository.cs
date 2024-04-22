using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataMatrix_TestApp.Interfaces
{
    public interface IGenericRepository<T>
    {
        Task<IEnumerable<T>> GetPaged(int page = 1, int perPage = 10);

        Task<T?> GetById(object id);

        Task<T?> Insert(T entity);

        Task<string> Delete(object id);
        Task Delete(T entityToDelete);

        Task<T?> Update(T entityToUpdate);
    }
}
