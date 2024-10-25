

using FluentValidation;
using MiniNetflix.Core.Application.Interfaces.Repositories;

namespace MiniNetflix.Core.Application.Features.Producers.Command.Delete
{
    public class DeleteProducerCommandValidator : AbstractValidator<DeleteProducerCommand>
    {
        public DeleteProducerCommandValidator()
        {
            RuleFor(m => m.Id)
                .NotEmpty().WithMessage("El Id no puede estar vacio")
                .NotNull().WithMessage("El Id no puede Ser nulo")                
                .WithName("Id de la Productora");
        }
    }
}
