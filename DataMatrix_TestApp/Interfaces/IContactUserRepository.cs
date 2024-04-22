using DataMatrix_TestApp.Models;
using DataMatrix_TestApp.Repositories;

namespace DataMatrix_TestApp.Interfaces
{
    public interface IContactUserRepository : IGenericRepository<ContactUser>
    {
        Task<IEnumerable<ContactUser>> GetPaged(int page, int perPage);
    }
}
