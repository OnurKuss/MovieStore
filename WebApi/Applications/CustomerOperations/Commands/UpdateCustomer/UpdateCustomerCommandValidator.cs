using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Applications.CustomerOperations.Commands.UpdateCustomer
{
    public class UpdateCustomerCommandValidator : AbstractValidator<UpdateCustomerCommand>
    {
        public UpdateCustomerCommandValidator()
        {
            RuleFor(x => x.CustomerId).GreaterThan(0);
            RuleFor(x => x.Model.Name).NotNull().NotEmpty().MinimumLength(3);
            RuleFor(x => x.Model.LastName).NotNull().NotEmpty().MinimumLength(3);
        }
    }
}
