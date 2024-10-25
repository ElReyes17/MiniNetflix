using MediatR;
using MiniNetflix.Core.Application.Common;
using MiniNetflix.Core.Application.Dtos.Movies;
using MiniNetflix.Core.Application.Interfaces.Repositories;

namespace MiniNetflix.Core.Application.Features.Movies.Query.GetAll
{
    public class GetAllMovieQueryHandler(IMovieRepository movieRepository) : IRequestHandler<GetAllMovieQuery, Result<List<MovieDto>>>
    {
        public async Task<Result<List<MovieDto>>> Handle(GetAllMovieQuery request, CancellationToken cancellationToken)
        {
            var movieList = await movieRepository.GetAllWithIncludeAsync();

            var response = movieList.Select(dto => new MovieDto
            {
                MovieId = dto.MovieId,
                MovieName = dto.Name,
                CoverImage = dto.CoverImage,
                MovieLink = dto.Link,
                ProducerId = dto.ProducerId,               
                ProducerName = dto.Producer.Name,
                MovieGenres = dto.MovieGenres.Select(a => a.Genre.Name).ToList(),

            }).ToList();

            return Result<List<MovieDto>>.Success(response);
        }
    }
}
