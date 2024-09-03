
using FluentValidation;
using MiniNetflix.Core.Application.Exceptions;
using MiniNetflix.Core.Application.Interfaces.Repositories;
using System.Net;

namespace MiniNetflix.Core.Application.Features.Movies.Query.GetAll
{
    public class GetAllMovieQueryValidator : AbstractValidator<GetAllMovieQuery>
    {
        
        public GetAllMovieQueryValidator(IMovieRepository movieRepository)
        {         
                 RuleFor(x => x)
                 .MustAsync(async (query, cancellation) => {
                    var movieList = await movieRepository.GetAllAsync();
                    if (movieList.Count == 0)
                    {
                        throw new ApiException("No hay películas creadas", (int)HttpStatusCode.NotFound);
                    }
                    return true;
                  })
                 .WithMessage("La lista de películas está vacía");
        }
    }
}
