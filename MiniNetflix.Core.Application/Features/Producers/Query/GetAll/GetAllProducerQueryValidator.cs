

using FluentValidation;
using MiniNetflix.Core.Application.Exceptions;
using MiniNetflix.Core.Application.Interfaces.Repositories;
using System.Net;

namespace MiniNetflix.Core.Application.Features.Producers.Query.GetAll
{
    public class GetAllProducerQueryValidator : AbstractValidator<GetAllProducerQuery>
    {
        public GetAllProducerQueryValidator() {}
       
    }
}
