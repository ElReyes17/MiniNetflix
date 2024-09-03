
using FluentValidation;
using MiniNetflix.Core.Application.Interfaces.Repositories;

namespace MiniNetflix.Core.Application.Features.Genres.Command.Delete
{
    public class DeleteGenreCommandValidator : AbstractValidator<DeleteGenreCommand>
    {
        public DeleteGenreCommandValidator(IGenreRepository genreRepository)
        {
            RuleFor(g => g.Id)
               .NotEmpty().WithMessage("El Id no puede estar vacio")
               .NotNull().WithMessage("El Id no puede Ser nulo")
               .MustAsync(async (id, cancellationToken) =>
               !await genreRepository.isExist(id)).WithMessage("El Id Ingresado no existe")
               .WithName("Id del Genero");
        }
    }
}
