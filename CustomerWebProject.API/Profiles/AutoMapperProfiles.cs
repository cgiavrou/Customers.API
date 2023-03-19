using AutoMapper;
using CustomerWebProject.API.Controllers;
using DataModels = CustomerWebProject.API.DataModels;
using CustomerWebProject.API.DomainModels;

namespace CustomerWebProject.API.Profiles
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles() {

            CreateMap<DataModels.Customer, Customer>()
                .ReverseMap();

            CreateMap<DataModels.PhoneNumber, PhoneNumber>()
                .ReverseMap();

            CreateMap<DataModels.ContactMode, ContactMode>()
                .ReverseMap();
        }

    }
}
