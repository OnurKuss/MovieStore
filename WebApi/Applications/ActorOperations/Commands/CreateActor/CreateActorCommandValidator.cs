using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Applications.ActorOperations.Commands.CreateActor
{
    public class CreateActorCommandValidator:AbstractValidator<CreateActorCommand>
    {
        public CreateActorCommandValidator()
        {
            RuleFor(x => x.Model.Name).NotEmpty().NotNull().MinimumLength(3);
            RuleFor(x => x.Model.Surname).NotEmpty().NotNull().MinimumLength(3);
        }
    }
}
