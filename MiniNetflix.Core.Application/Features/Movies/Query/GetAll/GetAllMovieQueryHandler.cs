using MediatR;
using MiniNetflix.Core.Application.Common;
using MiniNetflix.Core.Application.Dtos.Movies;
using MiniNetflix.Core.Application.Exceptions;
using MiniNetflix.Core.Application.Interfaces.Repositories;
using System.Net;

namespace MiniNetflix.Core.Application.Features.Movies.Query.GetAll
{
    public class GetAllMovieQueryHandler(IMovieRepository movieRepository) : IRequestHandler<GetAllMovieQuery, Result<List<MovieDTO>>>
    {
        public async Task<Result<List<MovieDTO>>> Handle(GetAllMovieQuery request, CancellationToken cancellationToken)
        {
            var movieList = await movieRepository.GetAllWithIncludeAsync();

            if (movieList.Count == 0)
            {
                throw new ApiException("No hay películas creadas", (int)HttpStatusCode.NotFound);
            }

            var response = movieList.Select(dto => new MovieDTO
            {
                MovieId = dto.MovieId,
                MovieName = dto.MovieName,
                CoverImage = dto.CoverImage,
                ProducerId = dto.ProducerId,               
                ProducerName = dto.Producer.ProducerName,
                MovieGenres = dto.MovieGenres.Select(a => a.Genre.GenreName).ToList(),

            }).ToList();

            return Result<List<MovieDTO>>.Success(response);
        }
    }
}
