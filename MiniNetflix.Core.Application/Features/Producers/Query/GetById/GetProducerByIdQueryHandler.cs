using MediatR;
using MiniNetflix.Core.Application.Common;
using MiniNetflix.Core.Application.Dtos.Producers;
using MiniNetflix.Core.Application.Exceptions;
using MiniNetflix.Core.Application.Interfaces.Repositories;


namespace MiniNetflix.Core.Application.Features.Producers.Query.GetById
{
    public class GetProducerByIdQueryHandler(IProducerRepository producerRepository) : IRequestHandler<GetProducerByIdQuery, Result<ProducerDto>>
    {
        public async Task<Result<ProducerDto>> Handle(GetProducerByIdQuery request, CancellationToken cancellationToken)
        {
            if (!await producerRepository.IsExist(request.Id)) throw new ApiException("No existe una productora con ese Id", 404);

            var getProducer = await producerRepository.GetByIdAsync(request.Id);

            if (getProducer == null) throw new ApiException("No se pudo encontrar esa productora", 404);

            var response = new ProducerDto
            {
                ProducerId = getProducer.ProducerId,
                ProducerName = getProducer.Name
            };

            return Result<ProducerDto>.Success(response);
        }
    }
}
