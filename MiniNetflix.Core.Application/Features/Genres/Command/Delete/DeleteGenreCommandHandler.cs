

using MediatR;
using MiniNetflix.Core.Application.Common;
using MiniNetflix.Core.Application.Interfaces.Repositories;
using MiniNetflix.Core.Application.Interfaces.UnitOfWork;

namespace MiniNetflix.Core.Application.Features.Genres.Command.Delete
{
    public class DeleteGenreCommandHandler(IGenreRepository genreRepository, IUnitOfWork unitOfWork) : IRequestHandler<DeleteGenreCommand, Result<Unit>>
    {
        public async Task<Result<Unit>> Handle(DeleteGenreCommand request, CancellationToken cancellationToken)
        {
            if(!await genreRepository.isExist(request.Id))
            {
                return Result<Unit>.Failure("El id ingresado no existe");
            }

            var genre = await genreRepository.GetByIdAsync(request.Id);

            genreRepository.Delete(genre);

            await unitOfWork.SaveChangesAsync(cancellationToken);

            return Result<Unit>.Success(Unit.Value);
        }
    }
}
