

using FluentValidation;
using MiniNetflix.Core.Application.Interfaces.Repositories;

namespace MiniNetflix.Core.Application.Features.Movies.Command.Update
{
    public class UpdateMovieCommandValidator : AbstractValidator<UpdateMovieCommand>
    {
        public UpdateMovieCommandValidator(IMovieRepository movieRepository)
        {
            RuleFor(m => m.UpdateMovieDTO.MovieId)
                .NotEmpty().WithMessage("El Id no puede estar vacio")
                .NotNull().WithMessage("El Id no puede Ser nulo")
                .MustAsync(async (id, cancellationToken) =>
                !await movieRepository.isExist(id)).WithMessage("El Id Ingresado no existe")
                .WithName("Id de la Pelicula");

            RuleFor(m => m.UpdateMovieDTO.MovieName)
               .NotEmpty().WithMessage("El nombre de la pelicula no puede estar vacío")
               .NotNull().WithMessage("El nombre de la pelicula no puede ser nulo");

            RuleFor(m => m.UpdateMovieDTO.CoverImage)
                .NotEmpty().WithMessage("La imagen de la pelicula no puede estar vacío")
                .NotNull().WithMessage("La imagen de la pelicula no puede ser nulo");

            RuleFor(m => m.UpdateMovieDTO.MovieLink)
                .NotEmpty().WithMessage("El enlace de la pelicula no puede estar vacío")
                .NotNull().WithMessage("El enlace de la pelicula no puede ser nulo");

            RuleFor(m => m.UpdateMovieDTO.ProducerId)
                .NotEmpty().WithMessage("Tiene que indicar una productora a la pelicula, no puede estar vacía")
                .NotNull().WithMessage("La productora de la pelicula no puede ser nulo");

            RuleFor(m => m.UpdateMovieDTO.MovieGenres)
                .NotEmpty().WithMessage("Tiene que indicar uno o mas generos a la pelicula, no puede estar vacío")
                .NotNull().WithMessage("Los generos de la pelicula no pueden ser nulos");

        }
    }
}
