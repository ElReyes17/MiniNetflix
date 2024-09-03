

using FluentValidation;
using MiniNetflix.Core.Application.Interfaces.Repositories;

namespace MiniNetflix.Core.Application.Features.Producers.Command.Delete
{
    public class DeleteProducerCommandValidator : AbstractValidator<DeleteProducerCommand>
    {
        public DeleteProducerCommandValidator(IProducerRepository producerRepository)
        {
            RuleFor(m => m.Id)
                .NotEmpty().WithMessage("El Id no puede estar vacio")
                .NotNull().WithMessage("El Id no puede Ser nulo")
                .MustAsync(async (id, cancellationToken) =>
                !await producerRepository.isExist(id)).WithMessage("El Id Ingresado no existe")
                .WithName("Id de la Productora");
        }
    }
}
