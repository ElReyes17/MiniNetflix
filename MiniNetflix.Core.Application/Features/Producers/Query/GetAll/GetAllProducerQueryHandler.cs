using MediatR;
using MiniNetflix.Core.Application.Common;
using MiniNetflix.Core.Application.Dtos.Producers;
using MiniNetflix.Core.Application.Exceptions;
using MiniNetflix.Core.Application.Interfaces.Repositories;
using System.Net;

namespace MiniNetflix.Core.Application.Features.Producers.Query.GetAll
{
    public class GetAllProducerQueryHandler(IProducerRepository producerRepository) : IRequestHandler<GetAllProducerQuery, Result<List<ProducerDto>>>
    {
        public async Task<Result<List<ProducerDto>>> Handle(GetAllProducerQuery request, CancellationToken cancellationToken)
        {
            var producerList = await producerRepository.GetAllAsync();

            if (producerList.Count == 0) throw new ApiException("No hay productoras creadas", 404);
            
            var response = producerList.Select(dto => new ProducerDto
            {
                ProducerId = dto.ProducerId,
                ProducerName = dto.Name,

            }).ToList();

            return Result<List<ProducerDto>>.Success(response);
        }
    }
}
