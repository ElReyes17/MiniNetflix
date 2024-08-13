

using MediatR;
using MiniNetflix.Core.Application.Common;
using MiniNetflix.Core.Application.Interfaces.Repositories;
using MiniNetflix.Core.Domain.Entities;

namespace MiniNetflix.Core.Application.Features.Genres.Command.Create
{
    public class CreateGenreCommandHandler(IGenreRepository genreRepository) : IRequestHandler<CreateGenreCommand, Result<Unit>>
    {
        public Task<Result<Unit>> Handle(CreateGenreCommand request, CancellationToken cancellationToken)
        {
            var mapGenre = new Genre();

            mapGenre.GenreName = request.createGenreDTO.GenreName;
                      
            genreRepository.Add(mapGenre);

            return Task.FromResult(Result<Unit>.Success(Unit.Value));

        }
    }
}