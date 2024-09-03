
using FluentValidation;
using MiniNetflix.Core.Application.Interfaces.Repositories;

namespace MiniNetflix.Core.Application.Features.Producers.Command.Update
{
    public class UpdateProducerCommandValidator : AbstractValidator<UpdateProducerCommand>
    {
        public UpdateProducerCommandValidator(IProducerRepository producerRepository)
        {
            RuleFor(g => g.UpdateProducerDTO.ProducerId)
                .NotEmpty().WithMessage("El Id no puede estar vacio")
                .NotNull().WithMessage("El Id no puede Ser nulo")
                .MustAsync(async (id, cancellationToken) =>
                !await producerRepository.isExist(id)).WithMessage("El Id Ingresado no existe")
                .WithName("Id de la productora");

            RuleFor(g => g.UpdateProducerDTO.ProducerName)
              .NotEmpty().WithMessage("El nombre de la productora no puede estar vacio")
              .NotNull().WithMessage("El nombre de la productora no puede ser nulo");
        }
    }
}
