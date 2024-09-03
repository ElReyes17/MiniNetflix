

using FluentValidation;
using MiniNetflix.Core.Application.Exceptions;
using MiniNetflix.Core.Application.Interfaces.Repositories;

namespace MiniNetflix.Core.Application.Features.Movies.Query.GetById
{
    public class GetMovieByIdQueryValidator : AbstractValidator<GetMovieByIdQuery>  
    {
        public GetMovieByIdQueryValidator(IMovieRepository movieRepository)
        {
               RuleFor(m => m.Id)
                   .NotEmpty().WithMessage("El Id no puede estar vacío.")
                   .NotNull().WithMessage("El Id no puede ser nulo.")
                   .MustAsync(async (id, cancellationToken) =>
                    await movieRepository.isExist(id))
                   .WithMessage("No existe una película con ese Id.")
                   .MustAsync(async (id, cancellationToken) =>
                   {
                        var movie = await movieRepository.FindByIdIncludeAsync(id);
                        if (movie == null)
                        {
                           throw new ApiException("La película no pudo ser encontrada", 404);
                        }
                         return true;
                   });


        }
    }
}
