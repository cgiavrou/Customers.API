using AutoMapper;
using CustomerWebProject.API.DomainModels;
using CustomerWebProject.API.Profiles.AfterMaps;
using DataModels = CustomerWebProject.API.DataModels;

namespace CustomerWebProject.API.Profiles
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles() {

            CreateMap<DataModels.Customer, Customer>()
                .ReverseMap();

            CreateMap<DataModels.PhoneNumber, PhoneNumber>()
                .ReverseMap();

            CreateMap<AddCustomerRequest, DataModels.Customer>()
                .AfterMap<AddCustomerRequestAfterMapping>();

            CreateMap<UpdateCustomerRequest, DataModels.Customer>()
                .AfterMap<UpdateCustomerRequestAfterMapping>();

        }

    }
}
