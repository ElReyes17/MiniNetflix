using MediatR;
using MiniNetflix.Core.Application.Common;
using MiniNetflix.Core.Application.Dtos.Genres;
using MiniNetflix.Core.Application.Interfaces.Repositories;


namespace MiniNetflix.Core.Application.Features.Genres.Query.GetAll
{
    public class GetAllGenreQueryHandler(IGenreRepository genreRepository) : IRequestHandler<GetAllGenreQuery, Result<List<GenreDTO>>>
    {
        public async Task<Result<List<GenreDTO>>> Handle(GetAllGenreQuery request, CancellationToken cancellationToken)
        {
            var genreList = await genreRepository.GetAllAsync();

            if (genreList.Count == 0)
            {
                return Result<List<GenreDTO>>.Failure("No hay generos creados");
            }

            var response = genreList.Select(dto => new GenreDTO
            {
                GenreId = dto.GenreId,
                GenreName = dto.GenreName,
                
            }).ToList();

            return Result<List<GenreDTO>>.Success(response);          
           
        }
    }
}
