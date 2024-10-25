using MediatR;
using MiniNetflix.Core.Application.Common;
using MiniNetflix.Core.Application.Exceptions;
using MiniNetflix.Core.Application.Interfaces.Repositories;
using MiniNetflix.Core.Application.Interfaces.UnitOfWork;

namespace MiniNetflix.Core.Application.Features.Genres.Command.Delete
{
    public class DeleteGenreCommandHandler(IGenreRepository genreRepository, IUnitOfWork unitOfWork) : IRequestHandler<DeleteGenreCommand, Result<Unit>>
    {
        public async Task<Result<Unit>> Handle(DeleteGenreCommand request, CancellationToken cancellationToken)
        {
            if(!await genreRepository.IsExist(request.Id)) throw new ApiException("El id no existe", 404);

            var genre = await genreRepository.GetByIdAsync(request.Id);

            if (genre == null) throw new ApiException("El genero no se ha podido encontrar", 400);

            genreRepository.Delete(genre);

            await unitOfWork.SaveChangesAsync(cancellationToken);

            return Result<Unit>.Success(Unit.Value);
        }
    }
}
