using AutoMapper;
using CustomerWebProject.API.DomainModels;

namespace CustomerWebProject.API.Profiles.AfterMaps
{
    public class AddCustomerRequestAfterMapping : IMappingAction<AddCustomerRequest, DataModels.Customer>
    {
        public void Process(AddCustomerRequest source, DataModels.Customer destination, ResolutionContext context)
        {
            destination.Id = Guid.NewGuid();
            destination.PhoneNumber = new DataModels.PhoneNumber()
            {
                Id =   Guid.NewGuid(),
                Mobile = source.Mobile,
                HomePhone = source.HomePhone,
                WorkPhone = source.WorkPhone
            };
        }
    }
}
