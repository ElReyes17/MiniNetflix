using MediatR;
using MiniNetflix.Core.Application.Common;
using MiniNetflix.Core.Application.Dtos.Movies;
using MiniNetflix.Core.Application.Exceptions;
using MiniNetflix.Core.Application.Interfaces.Repositories;

namespace MiniNetflix.Core.Application.Features.Movies.Query.GetById
{
    public class GetMovieByIdQueryHandler(IMovieRepository movieRepository) : IRequestHandler<GetMovieByIdQuery, Result<MovieDTO>>
    {
        public async Task<Result<MovieDTO>> Handle(GetMovieByIdQuery request, CancellationToken cancellationToken)
        {

            var movie = await movieRepository.FindByIdIncludeAsync(request.Id);

            if(!await movieRepository.isExist(request.Id))
            {
                throw new ApiException("El Id ingresado no existe", 400);
            }

            if(movie == null)
            {
                throw new ApiException("La pelicula no pudo ser encontrada", 404);
            }

            MovieDTO movieDTO = new MovieDTO
            {
                MovieId = movie.MovieId,
                MovieName = movie.MovieName,
                CoverImage = movie.CoverImage,
                MovieLink = movie.MovieLink,
                ProducerName = movie.Producer.ProducerName,
                MovieGenres = movie.MovieGenres.Select(mv => mv.Genre.GenreName).ToList(),

            };

            return Result<MovieDTO>.Success(movieDTO);
        }
    }

}
