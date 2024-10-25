

using MediatR;
using MiniNetflix.Core.Application.Common;
using MiniNetflix.Core.Application.Interfaces.Repositories;
using MiniNetflix.Core.Application.Interfaces.UnitOfWork;
using MiniNetflix.Core.Domain.Entities;

namespace MiniNetflix.Core.Application.Features.Movies.Command.Create
{
    public class CreateMovieCommandHandler(
        IMovieRepository movieRepository, 
        IUnitOfWork unitOfWork) 
        : IRequestHandler<CreateMovieCommand, Result<Unit>>
    {
        public async Task<Result<Unit>> Handle(CreateMovieCommand request, CancellationToken cancellationToken)
        {
            var mapMovie = new Movie
            {
                Name = request.MovieName,
                CoverImage = request.CoverImage,
                Link = request.MovieLink,
                ProducerId = request.ProducerId,
                MovieGenres = request.MovieGenres.Select(ids => new MovieGenre
                {
                    GenreId = ids,

                }).ToList()
                
            };

            movieRepository.Add(mapMovie);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            return Result<Unit>.Success(Unit.Value);
      
        }
    }
}
