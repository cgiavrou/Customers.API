using CustomerWebProject.API.DataModels;

namespace CustomerWebProject.API.DomainModels
{
    public class Customer
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string HomeAddress { get; set; }

        public Guid ContactId { get; set; }
        
        public ContactMode ContactMode { get; set; }
        
        public PhoneNumber PhoneNumber { get; set; }
    }
}
