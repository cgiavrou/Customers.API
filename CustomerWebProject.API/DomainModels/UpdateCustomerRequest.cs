namespace CustomerWebProject.API.DomainModels
{
    public class UpdateCustomerRequest
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string HomeAddress { get; set; }

        public Guid ContactId { get; set; }

        public long Mobile { get; set; }

        public long HomePhone { get; set; }

        public long WorkPhone { get; set; }

    }
}
