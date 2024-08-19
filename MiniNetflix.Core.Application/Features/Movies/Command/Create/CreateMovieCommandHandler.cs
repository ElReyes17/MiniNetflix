

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
                MovieName = request.createMovieDTO.MovieName,
                CoverImage = request.createMovieDTO.CoverImage,
                ProducerId = request.createMovieDTO.ProducerId,
                MovieGenres = request.createMovieDTO.MovieGenres.Select(ids => new MovieGenre
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
