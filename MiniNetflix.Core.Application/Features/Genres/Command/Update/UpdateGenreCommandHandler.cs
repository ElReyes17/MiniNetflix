

using MediatR;
using MiniNetflix.Core.Application.Common;
using MiniNetflix.Core.Application.Interfaces.Repositories;
using MiniNetflix.Core.Application.Interfaces.UnitOfWork;
using MiniNetflix.Core.Domain.Entities;

namespace MiniNetflix.Core.Application.Features.Genres.Command.Update
{
    public class UpdateGenreCommandHandler(IGenreRepository genreRepository, IUnitOfWork unitOfWork) : IRequestHandler<UpdateGenreCommand, Result<Unit>>
    {
        public async Task<Result<Unit>> Handle(UpdateGenreCommand request, CancellationToken cancellationToken)
        {
            if(!await genreRepository.isExist(request.updateGenreDTO.GenreId))
            {
                return Result<Unit>.Failure("El id ingresado no existe");
            }

            var getGenre = await genreRepository.GetByIdAsync(request.updateGenreDTO.GenreId);

            Genre genre = new Genre
            {
                GenreId = request.updateGenreDTO.GenreId,
                GenreName = request.updateGenreDTO.GenreName
            };

            genreRepository.Update(genre, genre.GenreId);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            return Result<Unit>.Success(Unit.Value);
        }
    }
}
