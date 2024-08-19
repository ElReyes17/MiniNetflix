using MediatR;
using MiniNetflix.Core.Application.Common;
using MiniNetflix.Core.Application.Dtos.Producers;
using MiniNetflix.Core.Application.Exceptions;
using MiniNetflix.Core.Application.Interfaces.Repositories;

namespace MiniNetflix.Core.Application.Features.Producers.Query.GetById
{
    public class GetProducerByIdQueryHandler(IProducerRepository producerRepository) : IRequestHandler<GetProducerByIdQuery, Result<ProducerDTO>>
    {
        public async Task<Result<ProducerDTO>> Handle(GetProducerByIdQuery request, CancellationToken cancellationToken)
        {
            if (!await producerRepository.isExist(request.Id))
            {
                throw new ApiException("El id no existe", 404);
            }

            var getProducer = await producerRepository.GetByIdAsync(request.Id);

            var response = new ProducerDTO
            {
                ProducerId = getProducer.ProducerId,
                ProducerName = getProducer.ProducerName
            };

            return Result<ProducerDTO>.Success(response);
        }
    }
}
