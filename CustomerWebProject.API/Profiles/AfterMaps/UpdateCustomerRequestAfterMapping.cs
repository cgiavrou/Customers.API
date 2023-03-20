
using AutoMapper;
using CustomerWebProject.API.DomainModels;

namespace CustomerWebProject.API.Profiles.AfterMaps
{
    public class UpdateCustomerRequestAfterMapping : IMappingAction<UpdateCustomerRequest, DataModels.Customer>
    {
        public void Process(UpdateCustomerRequest source, DataModels.Customer destination, ResolutionContext context)
        {
            destination.PhoneNumber = new DataModels.PhoneNumber()
            {
                Mobile = source.Mobile,
                HomePhone = source.HomePhone,
                WorkPhone = source.WorkPhone
            };
        }
    }
}
