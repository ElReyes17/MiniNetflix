

using FluentValidation;
using MiniNetflix.Core.Application.Exceptions;
using MiniNetflix.Core.Application.Interfaces.Repositories;
using System.Net;

namespace MiniNetflix.Core.Application.Features.Genres.Query.GetAll
{
    public class GetAllGenreQueryValidator : AbstractValidator<GetAllGenreQuery>
    {
        public GetAllGenreQueryValidator(IGenreRepository genreRepository)
        {
            RuleFor(x => x)
                .MustAsync(async (query, cancellation) =>
                {
                    var genreList = await genreRepository.GetAllAsync();
                    if (genreList.Count == 0) throw new ApiException("No hay generos creados", 404);                  
                    return true;
                });
                
        }
    }
}
