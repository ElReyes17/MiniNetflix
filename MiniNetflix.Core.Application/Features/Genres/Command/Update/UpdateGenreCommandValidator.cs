

using FluentValidation;
using MiniNetflix.Core.Application.Interfaces.Repositories;

namespace MiniNetflix.Core.Application.Features.Genres.Command.Update
{
    public class UpdateGenreCommandValidator : AbstractValidator<UpdateGenreCommand>
    {
        public UpdateGenreCommandValidator(IGenreRepository genreRepository)
        {
            RuleFor(g => g.GenreId)
                 .NotEmpty().WithMessage("El Id no puede estar vacio")
                 .NotNull().WithMessage("El Id no puede Ser nulo")
                 .MustAsync(async (id, cancellationToken) =>
                 !await genreRepository.IsExist(id)).WithMessage("El Id Ingresado no existe")
                 .WithName("Id del Genero");

            RuleFor(g => g.GenreName)
              .NotEmpty().WithMessage("El nombre del genero no puede estar vacio")
              .NotNull().WithMessage("El nombre del genero no puede ser nulo");
        }
    }
}
