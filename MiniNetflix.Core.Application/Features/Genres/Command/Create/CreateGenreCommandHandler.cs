using MediatR;
using MiniNetflix.Core.Application.Common;
using MiniNetflix.Core.Application.Interfaces.Repositories;
using MiniNetflix.Core.Application.Interfaces.UnitOfWork;
using MiniNetflix.Core.Domain.Entities;

namespace MiniNetflix.Core.Application.Features.Genres.Command.Create
{
    public class CreateGenreCommandHandler(IGenreRepository genreRepository, IUnitOfWork unitOfWork) : IRequestHandler<CreateGenreCommand, Result<Unit>>
    {
        public async Task<Result<Unit>> Handle(CreateGenreCommand request, CancellationToken cancellationToken)
        {
            var mapGenre = new Genre
            {
                Name = request.GenreName
            };
                     
            genreRepository.Add(mapGenre);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            return Result<Unit>.Success(Unit.Value);

        }
    }
}