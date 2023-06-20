using Application.Common.Response;
using Application.Cqrs.ArtificialIntelligence.Commands;
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
    public class GetArtificialIntelligenceQuery : IRequest<ApiResponse<List<ArtificialIntelligenceDto>>>
    {
    }
    public class GetArtificialIntelligenceQueryHandler : IRequestHandler<GetArtificialIntelligenceQuery, ApiResponse<List<ArtificialIntelligenceDto>>>
    {
        private readonly IArtificialIntelligenceService _artificialIntelligenceService;
        public GetArtificialIntelligenceQueryHandler(IArtificialIntelligenceService artificialIntelligenceService)
        {
            _artificialIntelligenceService = artificialIntelligenceService;
        }

        public async Task<ApiResponse<List<ArtificialIntelligenceDto>>> Handle(GetArtificialIntelligenceQuery request, CancellationToken cancellationToken)
        {
            return await _artificialIntelligenceService.GetArtificialIntelligence(request);
        }
    }
    
}
