using Application.Common.Response;
using Application.DTOs.ArtificialIntelligence;
using Application.Interfaces.ArtificialIntelligence;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Cqrs.ArtificialIntelligence.Commands
{
    public class PostArtificialIntelligenceCommand : IRequest<ApiResponse<ArtificialIntelligenceDto>>
    {
        public IFormFile Image { get; set; }
        public ArtificialIntelligencePostDto ArtificialIntelligencePostDto { get; set; }
    }
    public class PostCategoriesAICommandHandler : IRequestHandler<PostArtificialIntelligenceCommand, ApiResponse<ArtificialIntelligenceDto>>
    {
        private readonly IArtificialIntelligenceService _artificialIntelligenceService;
        public PostCategoriesAICommandHandler(IArtificialIntelligenceService artificialIntelligenceService)
        {
            _artificialIntelligenceService = artificialIntelligenceService;
        }

        public async Task<ApiResponse<ArtificialIntelligenceDto>> Handle(PostArtificialIntelligenceCommand request, CancellationToken cancellationToken)
        {
            return await _artificialIntelligenceService.AddArtificialIntelligence(request);
        }
    }
}
