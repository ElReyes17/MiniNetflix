

using FluentValidation;
using MiniNetflix.Core.Application.Interfaces.Repositories;

namespace MiniNetflix.Core.Application.Features.Movies.Query.GetById
{
    public class GetMovieByIdQueryValidator : AbstractValidator<GetMovieByIdQuery>  
    {
        public GetMovieByIdQueryValidator(IMovieRepository movieRepository)
        {
            RuleFor(m => m.Id)
                .NotEmpty().WithMessage("")
                .NotNull().WithMessage("")
                .MustAsync(async (id, cancellationToken) =>
                !await movieRepository.isExist(id)).WithMessage("");
            
        }
    }
}
