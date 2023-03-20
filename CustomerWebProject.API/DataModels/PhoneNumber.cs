namespace CustomerWebProject.API.DataModels
{
    public class PhoneNumber
    {
        public Guid  Id { get; set; }

        public long Mobile { get; set; }

        public long HomePhone { get; set; }

        public long WorkPhone { get; set; }

        //Navigation properties
        public Guid CustomerId { get; set; }
    }
}
