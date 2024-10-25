

using FluentValidation;

namespace MiniNetflix.Core.Application.Features.Genres.Command.Create
{
    public class CreateGenreCommandValidator : AbstractValidator<CreateGenreCommand>
    {
        public CreateGenreCommandValidator()
        {
            RuleFor(g => g.GenreName)
                .NotEmpty().WithMessage("El nombre del genero no puede estar vacio")
                .NotNull().WithMessage("El nombre del genero no puede ser nulo");
                 
        }
    }
}
