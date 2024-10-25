using MediatR;
using MiniNetflix.Core.Application.Common;
using MiniNetflix.Core.Application.Dtos.Movies;
using MiniNetflix.Core.Application.Interfaces.Repositories;

namespace MiniNetflix.Core.Application.Features.Movies.Query.GetById
{
    public class GetMovieByIdQueryHandler(IMovieRepository movieRepository) : IRequestHandler<GetMovieByIdQuery, Result<MovieDto>>
    {
        public async Task<Result<MovieDto>> Handle(GetMovieByIdQuery request, CancellationToken cancellationToken)
        {

            var movie = await movieRepository.FindByIdIncludeAsync(request.Id);

            MovieDto movieDTO = new MovieDto
            {
                MovieId = movie.MovieId,
                MovieName = movie.Name,
                CoverImage = movie.CoverImage,
                MovieLink = movie.Link,
                ProducerName = movie.Producer.Name,
                MovieGenres = movie.MovieGenres.Select(mv => mv.Genre.Name).ToList(),

            };

            return Result<MovieDto>.Success(movieDTO);
        }
    }

}
