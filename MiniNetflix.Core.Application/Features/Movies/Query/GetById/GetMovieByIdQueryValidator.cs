

using FluentValidation;
using MiniNetflix.Core.Application.Interfaces.Repositories;

namespace MiniNetflix.Core.Application.Features.Movies.Query.GetById
{
    public class GetMovieByIdQueryValidator : AbstractValidator<GetMovieByIdQuery>  
    {
        public GetMovieByIdQueryValidator(IMovieRepository movieRepository)
        {
            RuleFor(m => m.Id)
                .NotEmpty().WithMessage("el Id no puede estar Vacío")
                .NotNull().WithMessage("El Id no puede ser Nulo")
                .MustAsync(async (id, cancellationToken) =>
                !await movieRepository.isExist(id)).WithMessage("No existe una pelicula con ese Id");
            
        }
    }
}
