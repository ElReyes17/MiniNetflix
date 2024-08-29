using FluentValidation;

namespace MiniNetflix.Core.Application.Features.Movies.Command.Create
{
    public class CreateMovieCommandValidator : AbstractValidator<CreateMovieCommand>
    {
        public CreateMovieCommandValidator()
        {
            RuleFor(m => m.createMovieDTO.MovieName)
                .NotEmpty().WithMessage("El nombre de la pelicula no puede estar vacío")
                .NotNull().WithMessage("El nombre de la pelicula no puede ser nulo");

        }
    }
}
