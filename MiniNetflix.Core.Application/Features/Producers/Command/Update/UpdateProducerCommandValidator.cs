
using FluentValidation;
using MiniNetflix.Core.Application.Interfaces.Repositories;

namespace MiniNetflix.Core.Application.Features.Producers.Command.Update
{
    public class UpdateProducerCommandValidator : AbstractValidator<UpdateProducerCommand>
    {
        public UpdateProducerCommandValidator(IProducerRepository producerRepository)
        {
            RuleFor(g => g.ProducerId)
                .NotEmpty().WithMessage("El Id no puede estar vacio")
                .NotNull().WithMessage("El Id no puede Ser nulo")               
                .WithName("Id de la productora");

            RuleFor(g => g.ProducerName)
              .NotEmpty().WithMessage("El nombre de la productora no puede estar vacio")
              .NotNull().WithMessage("El nombre de la productora no puede ser nulo");
        }
    }
}
