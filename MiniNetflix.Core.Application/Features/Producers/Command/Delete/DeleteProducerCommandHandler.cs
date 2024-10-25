

using MediatR;
using MiniNetflix.Core.Application.Common;
using MiniNetflix.Core.Application.Exceptions;
using MiniNetflix.Core.Application.Interfaces.Repositories;
using MiniNetflix.Core.Application.Interfaces.UnitOfWork;

namespace MiniNetflix.Core.Application.Features.Producers.Command.Delete
{
    public class DeleteProducerCommandHandler(IProducerRepository producerRepository, IUnitOfWork unitOfWork) : IRequestHandler<DeleteProducerCommand, Result<Unit>>
    {
        public async Task<Result<Unit>> Handle(DeleteProducerCommand request, CancellationToken cancellationToken)
        {
            if (!await producerRepository.IsExist(request.Id)) throw new ApiException("No existe una productora con ese Id", 404);

            var genre = await producerRepository.GetByIdAsync(request.Id);

            if (genre == null) throw new ApiException("No se pudo encontrar esa productora", 404);
           
            producerRepository.Delete(genre);

            await unitOfWork.SaveChangesAsync(cancellationToken);

            return Result<Unit>.Success(Unit.Value);
        }
    }
}
