

using FluentValidation;

namespace MiniNetflix.Core.Application.Features.Producers.Command.Create
{
    public class CreateProducerCommandValidator : AbstractValidator<CreateProducerCommand>
    {
        public CreateProducerCommandValidator()
        {
            RuleFor(m => m.ProducerName)
               .NotEmpty().WithMessage("El nombre de la productora no puede estar vacío")
               .NotNull().WithMessage("El nombre de la productora no puede ser nulo");
        }
    }
}
