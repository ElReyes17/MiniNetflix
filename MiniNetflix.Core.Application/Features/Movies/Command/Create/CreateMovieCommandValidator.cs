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
                .NotEmpty().WithMessage("La imagen de la pelicula no puede estar vacío")
                .NotNull().WithMessage("La imagen de la pelicula no puede ser nulo");

            RuleFor(m => m.createMovieDTO.MovieLink)
                .NotEmpty().WithMessage("El enlace de la pelicula no puede estar vacío")
                .NotNull().WithMessage("El enlace de la pelicula no puede ser nulo");

            RuleFor(m => m.createMovieDTO.ProducerId)
                .NotEmpty().WithMessage("Tiene que indicar una productora a la pelicula, no puede estar vacía")
                .NotNull().WithMessage("La productora de la pelicula no puede ser nulo");

            RuleFor(m => m.createMovieDTO.MovieGenres)
                .NotEmpty().WithMessage("Tiene que indicar uno o mas generos a la pelicula, no puede estar vacío")
                .NotNull().WithMessage("Los generos de la pelicula no pueden ser nulos");

        }
    }
}
