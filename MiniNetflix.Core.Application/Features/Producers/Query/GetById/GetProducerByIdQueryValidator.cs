

using FluentValidation;
using MiniNetflix.Core.Application.Exceptions;
using MiniNetflix.Core.Application.Interfaces.Repositories;

namespace MiniNetflix.Core.Application.Features.Producers.Query.GetById
{
    public class GetProducerByIdQueryValidator : AbstractValidator<GetProducerByIdQuery>
    {
        public GetProducerByIdQueryValidator(IProducerRepository producerRepository)
        {
            RuleFor(p => p.Id)
                   .NotEmpty().WithMessage("El Id no puede estar vacío.")
                   .NotNull().WithMessage("El Id no puede ser nulo.")
                   .MustAsync(async (id, cancellationToken) =>
                    await producerRepository.isExist(id))
                   .WithMessage("No existe una productora con ese Id.");
                  
        }
    }
}
