using Application.Common.Response;
using Application.Cqrs.ArtificialIntelligence.Commands;
using Application.Cqrs.ArtificialIntelligence.Queries;
using Application.DTOs.ArtificialIntelligence;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces.ArtificialIntelligence
{
    public interface IArtificialIntelligenceService
    {
        Task<ApiResponse<ArtificialIntelligenceDto>> AddArtificialIntelligence(PostArtificialIntelligenceCommand request);
        Task<ApiResponse<List<ArtificialIntelligenceDto>>> GetArtificialIntelligence(GetArtificialIntelligenceQuery request);
        Task<ApiResponse<List<ArtificialIntelligenceDto>>> GetArtificialIntelligenceNew();
        Task<ApiResponse<ArtificialIntelligenceDto>> UpdateArtificialIntelligence(PutArtificialIntelligenceCommand request);
        Task<ApiResponse<bool>> DeleteArtificialIntelligence(DeleteArtificialIntelligenceCommand request);
        Task<ApiResponse<ArtificialIntelligenceDto>> GetArtificialIntelligenceById(GetArtificialIntelligenceQueryById request);
    }
}