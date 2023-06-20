using Application.Common.Response;
using Application.DTOs.ArtificialIntelligence;
using Application.Interfaces.ArtificialIntelligence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Application.Cqrs.ArtificialIntelligence.Commands
{
    public class DeleteArtificialIntelligenceCommand : IRequest<ApiResponse<bool>>
    {
        public int Id { get; set; }
    }
    public class DeleteArtificialIntelligenceCommandHandler : IRequestHandler<DeleteArtificialIntelligenceCommand, ApiResponse<bool>>
    {
        private readonly IArtificialIntelligenceService _artificialIntelligenceService;
        public DeleteArtificialIntelligenceCommandHandler(IArtificialIntelligenceService artificialIntelligenceService)
        {
            _artificialIntelligenceService = artificialIntelligenceService;
        }

        public async Task<ApiResponse<bool>> Handle(DeleteArtificialIntelligenceCommand request, CancellationToken cancellationToken)
        {
            return await _artificialIntelligenceService.DeleteArtificialIntelligence(request);
        }
    }
}
