using MediatR;
using MiniNetflix.Core.Application.Common;
using MiniNetflix.Core.Application.Dtos.Genres;
using MiniNetflix.Core.Application.Exceptions;
using MiniNetflix.Core.Application.Interfaces.Repositories;
using System.Net;


namespace MiniNetflix.Core.Application.Features.Genres.Query.GetAll
{
    public class GetAllGenreQueryHandler(IGenreRepository genreRepository) : IRequestHandler<GetAllGenreQuery, Result<List<GenreDto>>>
    {
        public async Task<Result<List<GenreDto>>> Handle(GetAllGenreQuery request, CancellationToken cancellationToken)
        {
            var genreList = await genreRepository.GetAllAsync();

            var response = genreList.Select(dto => new GenreDto
            {
                GenreId = dto.GenreId,
                GenreName = dto.Name,
                
            }).ToList();

            return Result<List<GenreDto>>.Success(response);          
           
        }
    }
}
