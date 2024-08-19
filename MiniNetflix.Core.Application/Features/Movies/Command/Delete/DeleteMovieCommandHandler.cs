﻿
using MediatR;
using MiniNetflix.Core.Application.Common;
using MiniNetflix.Core.Application.Exceptions;
using MiniNetflix.Core.Application.Interfaces.Repositories;
using MiniNetflix.Core.Application.Interfaces.UnitOfWork;

namespace MiniNetflix.Core.Application.Features.Movies.Command.Delete
{
    public class DeleteMovieCommandHandler(IMovieRepository movieRepository, IUnitOfWork unitOfWork) : IRequestHandler<DeleteMovieCommand, Result<Unit>>
    {
        public async Task<Result<Unit>> Handle(DeleteMovieCommand request, CancellationToken cancellationToken)
        {

            if (!await movieRepository.isExist(request.Id))
            {
                throw new ApiException("El id no existe", 404);
            }

            var movie = await movieRepository.GetByIdAsync(request.Id);

            movieRepository.Delete(movie);

            await unitOfWork.SaveChangesAsync(cancellationToken);

            return Result<Unit>.Success(Unit.Value);
        }
    }
}
