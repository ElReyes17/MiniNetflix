

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
         
            Movie movie = new Movie
            {
                MovieId = request.MovieId,
                Name = request.MovieName,
                CoverImage = request.CoverImage,
                Link = request.MovieLink,
                ProducerId = request.ProducerId,
                MovieGenres = request.MovieGenres.Select(ids => new MovieGenre
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
