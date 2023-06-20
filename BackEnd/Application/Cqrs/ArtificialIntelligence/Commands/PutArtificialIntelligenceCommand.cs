using Application.Common.Response;
using Application.DTOs.ArtificialIntelligence;
using Application.Interfaces.ArtificialIntelligence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.AspNetCore.Http;

namespace Application.Cqrs.ArtificialIntelligence.Commands
{
    public class PutArtificialIntelligenceCommand : IRequest<ApiResponse<ArtificialIntelligenceDto>>
    {
        public IFormFile Image { get; set; }
        public ArtificialIntelligenceDto ArtificialIntelligencePostDto { get; set; }
    }
    public class PutArtificialIntelligenceCommandHandler : IRequestHandler<PutArtificialIntelligenceCommand, ApiResponse<ArtificialIntelligenceDto>>
    {
        private readonly IArtificialIntelligenceService _artificialIntelligenceService;
        public PutArtificialIntelligenceCommandHandler(IArtificialIntelligenceService artificialIntelligenceService)
        {
            _artificialIntelligenceService = artificialIntelligenceService;
        }

        public async Task<ApiResponse<ArtificialIntelligenceDto>> Handle(PutArtificialIntelligenceCommand request, CancellationToken cancellationToken)
        {
            return await _artificialIntelligenceService.UpdateArtificialIntelligence(request);
        }
    }
}
