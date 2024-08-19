using MediatR;
using MiniNetflix.Core.Application.Common;
using MiniNetflix.Core.Application.Dtos.Producers;
using MiniNetflix.Core.Application.Exceptions;
using MiniNetflix.Core.Application.Interfaces.Repositories;
using System.Net;

namespace MiniNetflix.Core.Application.Features.Producers.Query.GetAll
{
    public class GetAllProducerQueryHandler(IProducerRepository producerRepository) : IRequestHandler<GetAllProducerQuery, Result<List<ProducerDTO>>>
    {
        public async Task<Result<List<ProducerDTO>>> Handle(GetAllProducerQuery request, CancellationToken cancellationToken)
        {
            var producerList = await producerRepository.GetAllAsync();

            if (producerList.Count == 0)
            {
                throw new ApiException("No hay productoras creadas", (int)HttpStatusCode.NotFound);
            }

            var response = producerList.Select(dto => new ProducerDTO
            {
                ProducerId = dto.ProducerId,
                ProducerName = dto.ProducerName,

            }).ToList();

            return Result<List<ProducerDTO>>.Success(response);
        }
    }
}
