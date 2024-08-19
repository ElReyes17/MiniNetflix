

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
            if (!await producerRepository.isExist(request.Id))  
            {
                throw new ApiException("El id no existe", 404);
            }

            var genre = await producerRepository.GetByIdAsync(request.Id);

            producerRepository.Delete(genre);

            await unitOfWork.SaveChangesAsync(cancellationToken);

            return Result<Unit>.Success(Unit.Value);
        }
    }
}
