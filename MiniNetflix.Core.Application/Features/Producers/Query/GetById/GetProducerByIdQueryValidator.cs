using FluentValidation;
using MiniNetflix.Core.Application.Interfaces.Repositories;

namespace MiniNetflix.Core.Application.Features.Producers.Query.GetById
{
    public class GetProducerByIdQueryValidator : AbstractValidator<GetProducerByIdQuery>
    {
        public GetProducerByIdQueryValidator()
        {
            RuleFor(p => p.Id)
                   .NotEmpty().WithMessage("El Id de la productora no puede estar vacío.")
                   .NotNull().WithMessage("El Id de la productora no puede ser nulo.");                   ;
                  
        }
    }
}
