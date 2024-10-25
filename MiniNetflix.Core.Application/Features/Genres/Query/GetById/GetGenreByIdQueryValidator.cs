

using FluentValidation;
using MiniNetflix.Core.Application.Interfaces.Repositories;

namespace MiniNetflix.Core.Application.Features.Genres.Query.GetById
{
    public class GetGenreByIdQueryValidator : AbstractValidator<GetGenreByIdQuery>
    {
        public GetGenreByIdQueryValidator(IGenreRepository genreRepository)
        {
            RuleFor(m => m.Id)
                .NotEmpty().WithMessage("el Id no puede estar Vacío")
                .NotNull().WithMessage("El Id no puede ser Nulo")
                .MustAsync(async (id, cancellationToken) =>
                !await genreRepository.IsExist(id)).WithMessage("No existe un genero con ese Id");
        }
    }
}
