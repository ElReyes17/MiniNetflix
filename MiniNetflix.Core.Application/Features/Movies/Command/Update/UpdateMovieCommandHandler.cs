

using MediatR;
using MiniNetflix.Core.Application.Common;
using MiniNetflix.Core.Application.Exceptions;
using MiniNetflix.Core.Application.Interfaces.Repositories;
using MiniNetflix.Core.Application.Interfaces.UnitOfWork;
using MiniNetflix.Core.Domain.Entities;

namespace MiniNetflix.Core.Application.Features.Movies.Command.Update
{
    public class UpdateMovieCommandHandler(IMovieRepository movieRepository, IUnitOfWork unitOfWork) : IRequestHandler<UpdateMovieCommand, Result<Unit>>
    {
        public async Task<Result<Unit>> Handle(UpdateMovieCommand request, CancellationToken cancellationToken)
        {
            if (!await movieRepository.isExist(request.UpdateMovieDTO.MovieId))
            {
                throw new ApiException("El id no existe", 404);
            }

            Movie movie = new Movie
            {
                MovieId = request.UpdateMovieDTO.MovieId,
                MovieName = request.UpdateMovieDTO.MovieName,
                CoverImage = request.UpdateMovieDTO.CoverImage,
                MovieLink = request.UpdateMovieDTO.MovieLink,
                ProducerId = request.UpdateMovieDTO.ProducerId,
                MovieGenres = request.UpdateMovieDTO.MovieGenres.Select(ids => new MovieGenre
                {
                    GenreId = ids,

                }).ToList()
            };

            movieRepository.Update(movie, movie.MovieId);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            return Result<Unit>.Success(Unit.Value);
        }
    }
}
