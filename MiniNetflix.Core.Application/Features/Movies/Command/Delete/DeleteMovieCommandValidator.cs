

using FluentValidation;
using MiniNetflix.Core.Application.Interfaces.Repositories;

namespace MiniNetflix.Core.Application.Features.Movies.Command.Delete
{
    public class DeleteMovieCommandValidator : AbstractValidator<DeleteMovieCommand>
    {
        public DeleteMovieCommandValidator(IMovieRepository movieRepository)
        {

            RuleFor(m => m.Id)
                .NotEmpty().WithMessage("El Id no puede estar vacio")
                .NotNull().WithMessage("El Id no puede Ser nulo")
                .MustAsync(async (id, cancellationToken) =>
                !await movieRepository.isExist(id)).WithMessage("El Id Ingresado no existe")
                .WithName("Id de la Pelicula");
            
        }
    }
}
