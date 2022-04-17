using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Applications.ActorOperations.Queries.GetActorDetail
{
    public class GetActorDetailQueryValidator:AbstractValidator<GetActorDetailQuery>
    {
        public GetActorDetailQueryValidator()
        {
            RuleFor(x => x.ActorId).NotNull().NotEmpty().GreaterThan(0);
        }
    }
}
