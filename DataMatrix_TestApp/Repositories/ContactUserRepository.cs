using DataMatrix_TestApp.Data;
using DataMatrix_TestApp.Interfaces;
using DataMatrix_TestApp.Models;

namespace DataMatrix_TestApp.Repositories
{
    public class ContactUserRepository : GenericRepository<ContactUser>, IContactUserRepository
    {
        public ContactUserRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<ContactUser>> GetPaged(int page, int perPage)
        {
            return await base.GetPaged(page, perPage);
        }
    }
}
