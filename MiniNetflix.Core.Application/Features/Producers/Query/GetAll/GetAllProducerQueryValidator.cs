

using FluentValidation;
using MiniNetflix.Core.Application.Exceptions;
using MiniNetflix.Core.Application.Interfaces.Repositories;
using System.Net;

namespace MiniNetflix.Core.Application.Features.Producers.Query.GetAll
{
    public class GetAllProducerQueryValidator : AbstractValidator<GetAllProducerQuery>
    {
        public GetAllProducerQueryValidator(IProducerRepository producerRepository)
        {
            RuleFor(x => x)
                .MustAsync(async (query, cancellation) =>
                {
                    var producerList = await producerRepository.GetAllAsync();
                    if (producerList.Count == 0)
                    {
                        throw new ApiException("No hay productoras creadas", (int)HttpStatusCode.NotFound);
                    }
                    return true;
                });
        }
    }
}
