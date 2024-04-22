using DataMatrix_TestApp.Interfaces;
using DataMatrix_TestApp.Models;
using System.Text.RegularExpressions;

namespace DataMatrix_TestApp.Services
{
    public class ContactUserService : IContactUserService
    {
        private readonly IContactUserRepository _contactUserRepository;

        public ContactUserService(IContactUserRepository contactUserRepository)
        {
            _contactUserRepository = contactUserRepository;
        }

        public async Task<IEnumerable<ContactUser>> GetPaged(int page, int pageSize)
        {
            var result = await _contactUserRepository.GetPaged(page,pageSize);
            return result;
        }

        public async Task<ContactUser?> GetById(int id)
        {
            var result = await _contactUserRepository.GetById(id);
            return result;
        }

        public async Task<ContactUser?> AddContactUser(ContactUser contactUser)
        {
            if (!IsValidEmail(contactUser.Email!))
                return null;

            var result = await _contactUserRepository.Insert(contactUser);
            return result;
        }

        public async Task<ContactUser?> UpdateContactUser(ContactUser contactUser)
        {
            if (!IsValidEmail(contactUser.Email))
                return null;

            var result = await _contactUserRepository.Update(contactUser);
            return result;
        }

        public async Task<string> DeleteContactUser(int id)
        {
            var result = await _contactUserRepository.Delete(id);
            return result;
        }
        private bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            // Регулярное выражение для проверки формата email
            string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

            return Regex.IsMatch(email, emailPattern);
        }
    }
}
