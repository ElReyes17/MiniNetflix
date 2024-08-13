
using MediatR;
using MiniNetflix.Core.Application.Common;
using MiniNetflix.Core.Application.Dtos.Genres;
using MiniNetflix.Core.Application.Interfaces.Repositories;

namespace MiniNetflix.Core.Application.Features.Genres.Query.GetById
{
    public class GetGenreByIdQueryHandler(IGenreRepository genreRepository) : IRequestHandler<GetGenreByIdQuery, Result<GenreDTO>>
    {
        public async Task<Result<GenreDTO>> Handle(GetGenreByIdQuery request, CancellationToken cancellationToken)
        {
            if (!await genreRepository.isExist(request.id))
            {
                return Result<GenreDTO>.Failure("El id no existe");
            }

            var getGenre = await genreRepository.GetByIdAsync(request.id);

            var response = new GenreDTO
            {
                GenreId = getGenre.GenreId,
                GenreName = getGenre.GenreName
            };

            return Result<GenreDTO>.Success(response);  
        }
    }
}
