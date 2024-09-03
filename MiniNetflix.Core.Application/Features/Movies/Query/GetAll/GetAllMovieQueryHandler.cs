using MediatR;
using MiniNetflix.Core.Application.Common;
using MiniNetflix.Core.Application.Dtos.Movies;
using MiniNetflix.Core.Application.Interfaces.Repositories;

namespace MiniNetflix.Core.Application.Features.Movies.Query.GetAll
{
    public class GetAllMovieQueryHandler(IMovieRepository movieRepository) : IRequestHandler<GetAllMovieQuery, Result<List<MovieDTO>>>
    {
        public async Task<Result<List<MovieDTO>>> Handle(GetAllMovieQuery request, CancellationToken cancellationToken)
        {
            var movieList = await movieRepository.GetAllWithIncludeAsync();

            var response = movieList.Select(dto => new MovieDTO
            {
                MovieId = dto.MovieId,
                MovieName = dto.MovieName,
                CoverImage = dto.CoverImage,
                MovieLink = dto.MovieLink,
                ProducerId = dto.ProducerId,               
                ProducerName = dto.Producer.ProducerName,
                MovieGenres = dto.MovieGenres.Select(a => a.Genre.GenreName).ToList(),

            }).ToList();

            return Result<List<MovieDTO>>.Success(response);
        }
    }
}
