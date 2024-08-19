

using MediatR;
using MiniNetflix.Core.Application.Common;
using MiniNetflix.Core.Application.Interfaces.Repositories;
using MiniNetflix.Core.Application.Interfaces.UnitOfWork;
using MiniNetflix.Core.Domain.Entities;

namespace MiniNetflix.Core.Application.Features.Producers.Command.Create
{
    public class CreateProducerCommandHandler(IProducerRepository producerRepository, IUnitOfWork unitOfWork) : IRequestHandler<CreateProducerCommand, Result<Unit>>
    {
        public async Task<Result<Unit>> Handle(CreateProducerCommand request, CancellationToken cancellationToken)
        {
            var mapProducer = new Producer
            {
                ProducerName = request.createProducerDTO.ProducerName
            };

            producerRepository.Add(mapProducer);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            return Result<Unit>.Success(Unit.Value);
        }
    }
}
