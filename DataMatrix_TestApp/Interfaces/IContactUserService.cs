using DataMatrix_TestApp.Models;
using DataMatrix_TestApp.Repositories;

namespace DataMatrix_TestApp.Interfaces
{
    public interface IContactUserService
    {
        Task<IEnumerable<ContactUser>> GetPaged(int page, int pageSize);
        Task<ContactUser?> GetById(int id);
        Task<ContactUser?> AddContactUser(ContactUser contactUser);
        Task<ContactUser?> UpdateContactUser(ContactUser contactUser);
        Task<string> DeleteContactUser(int id);
    }
}
