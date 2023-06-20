using Application.Common.Response;
using Application.DTOs.ArtificialIntelligence;
using Application.Interfaces.ArtificialIntelligence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Application.Cqrs.ArtificialIntelligence.Queries
{
    public class GetArtificialIntelligenceQueryById : IRequest<ApiResponse<ArtificialIntelligenceDto>>
    {
        public int Id { get; set; }
    }
    public class etArtificialIntelligenceQueryByIdHandler : IRequestHandler<GetArtificialIntelligenceQueryById, ApiResponse<ArtificialIntelligenceDto>>
    {
        private readonly IArtificialIntelligenceService _artificialIntelligenceService;
        public etArtificialIntelligenceQueryByIdHandler(IArtificialIntelligenceService artificialIntelligenceService)
        {
            _artificialIntelligenceService = artificialIntelligenceService;
        }

        public async Task<ApiResponse<ArtificialIntelligenceDto>> Handle(GetArtificialIntelligenceQueryById request, CancellationToken cancellationToken)
        {
            return await _artificialIntelligenceService.GetArtificialIntelligenceById(request);
        }
    }
}
