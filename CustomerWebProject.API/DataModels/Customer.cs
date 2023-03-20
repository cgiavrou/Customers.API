namespace CustomerWebProject.API.DataModels
{
    public class Customer
    {
        public Guid Id { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Email { get; set; }

        public string? HomeAddress { get; set; }
        
        //Navigation Properties
        public PhoneNumber? PhoneNumber { get; set; }
    }
}
