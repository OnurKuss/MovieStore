using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Applications.ActorOperations.Commands.DeleteActor
{
    public class DeleteActorCommandValidator:AbstractValidator<DeleteActorCommand>
    {
        public DeleteActorCommandValidator()
        {
            RuleFor(x => x.ActorId).GreaterThan(0);
        }
    }
}
