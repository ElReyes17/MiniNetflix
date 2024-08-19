using MediatR;
using MiniNetflix.Core.Application.Common;
using MiniNetflix.Core.Application.Exceptions;
using MiniNetflix.Core.Application.Interfaces.Repositories;
using MiniNetflix.Core.Application.Interfaces.UnitOfWork;
using MiniNetflix.Core.Domain.Entities;


namespace MiniNetflix.Core.Application.Features.Producers.Command.Update
{
    public class UpdateProducerCommandHandler(IProducerRepository producerRepository, IUnitOfWork unitOfWork) : IRequestHandler<UpdateProducerCommand, Result<Unit>>
    {
        public async Task<Result<Unit>> Handle(UpdateProducerCommand request, CancellationToken cancellationToken)
        {
            if (!await producerRepository.isExist(request.UpdateProducerDTO.ProducerId))
            {
                throw new ApiException("El id no existe", 404);
            }

            var getProducer = await producerRepository.GetByIdAsync(request.UpdateProducerDTO.ProducerId);

            Producer producer = new Producer
            {
                ProducerId = request.UpdateProducerDTO.ProducerId,
                ProducerName = request.UpdateProducerDTO.ProducerName
            };

            producerRepository.Update(producer, producer.ProducerId);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            return Result<Unit>.Success(Unit.Value);
        }
    }
}
