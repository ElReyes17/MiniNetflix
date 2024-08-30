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

            RuleFor(m => m.createMovieDTO.CoverImage)
                .NotEmpty().WithMessage("El nombre de la pelicula no puede estar vacío")
                .NotNull().WithMessage("El nombre de la pelicula no puede ser nulo");

            RuleFor(m => m.createMovieDTO.MovieLink)
                .NotEmpty().WithMessage("El nombre de la pelicula no puede estar vacío")
                .NotNull().WithMessage("El nombre de la pelicula no puede ser nulo");

            RuleFor(m => m.createMovieDTO.ProducerId)
                .NotEmpty().WithMessage("El nombre de la pelicula no puede estar vacío")
                .NotNull().WithMessage("El nombre de la pelicula no puede ser nulo");

            RuleFor(m => m.createMovieDTO.MovieGenres)
                .NotEmpty().WithMessage("El nombre de la pelicula no puede estar vacío")
                .NotNull().WithMessage("El nombre de la pelicula no puede ser nulo");

        }
    }
}
