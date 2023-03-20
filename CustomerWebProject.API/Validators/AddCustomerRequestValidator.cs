using CustomerWebProject.API.DomainModels;
using CustomerWebProject.API.Repositories;
using FluentValidation;

namespace CustomerWebProject.API.Validators
{
    public class AddCustomerRequestValidator: AbstractValidator<AddCustomerRequest>
    {
        public AddCustomerRequestValidator(ICustomerRepository customerRepository) 
        {
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.HomeAddress).NotEmpty();
            RuleFor(x => x.Mobile).GreaterThan(99999).LessThan(10000000000);
            RuleFor(x => x.HomePhone).GreaterThan(99999).LessThan(10000000000);
            RuleFor(x => x.WorkPhone).GreaterThan(99999).LessThan(10000000000);
        }
    }
}
