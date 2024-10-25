using MediatR;
using MiniNetflix.Core.Application.Common;
using MiniNetflix.Core.Application.Dtos.Genres;
using MiniNetflix.Core.Application.Exceptions;
using MiniNetflix.Core.Application.Interfaces.Repositories;

namespace MiniNetflix.Core.Application.Features.Genres.Query.GetById
{
    public class GetGenreByIdQueryHandler(IGenreRepository genreRepository) : IRequestHandler<GetGenreByIdQuery, Result<GenreDto>>
    {
        public async Task<Result<GenreDto>> Handle(GetGenreByIdQuery request, CancellationToken cancellationToken)
        {   
            var getGenre = await genreRepository.GetByIdAsync(request.Id);

            if (getGenre == null) throw new ApiException("El genero no pudo ser encontrado", 404);

            var response = new GenreDto
            {
                GenreId = getGenre.GenreId,
                GenreName = getGenre.Name
            };

            return Result<GenreDto>.Success(response);  
        }
    }
}
