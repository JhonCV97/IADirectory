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
    public class GetArtificialIntelligenceNewQuery : IRequest<ApiResponse<List<ArtificialIntelligenceDto>>>
    {

    }
    public class GetArtificialIntelligenceNewQueryHandler : IRequestHandler<GetArtificialIntelligenceNewQuery, ApiResponse<List<ArtificialIntelligenceDto>>>
    {
        private readonly IArtificialIntelligenceService _artificialIntelligenceService;
        public GetArtificialIntelligenceNewQueryHandler(IArtificialIntelligenceService artificialIntelligenceService)
        {
            _artificialIntelligenceService = artificialIntelligenceService;
        }

        public async Task<ApiResponse<List<ArtificialIntelligenceDto>>> Handle(GetArtificialIntelligenceNewQuery request, CancellationToken cancellationToken)
        {
            return await _artificialIntelligenceService.GetArtificialIntelligenceNew();
        }
    }
}
