using DataMatrix_TestApp.Base;

namespace DataMatrix_TestApp.Models
{
    public class ContactUser : BaseEntity
    {
        public string Name { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string PhoneNumber { get; set; }
        public string? PhotoUrl { get; set; }
    }

    public class InputContactUser
    {
        public string Name { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string PhoneNumber { get; set; }
        public string? PhotoUrl { get; set; }
    }

}
