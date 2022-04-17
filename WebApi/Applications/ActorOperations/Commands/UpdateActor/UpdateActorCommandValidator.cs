using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Applications.ActorOperations.Commands.UpdateActor
{
    public class UpdateActorCommandValidator: AbstractValidator<UpdateActorCommand>
    {
        public UpdateActorCommandValidator()
        {
            RuleFor(x => x.ActorId).GreaterThan(0);
            RuleFor(x => x.Model.Name).NotNull().NotEmpty().MinimumLength(3);
            RuleFor(x => x.Model.Surname).NotNull().NotEmpty().MinimumLength(3);
        }
    }
}
