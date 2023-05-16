using Application.Common.Response;
using Application.Cqrs.ArtificialIntelligence.Commands;
using Application.DTOs.ArtificialIntelligence;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces.ArtificialIntelligence
{
    public interface IArtificialIntelligenceService
    {
        Task<ApiResponse<ArtificialIntelligenceDto>> AddArtificialIntelligence(PostArtificialIntelligenceCommand request);
        Task<ApiResponse<List<ArtificialIntelligenceDto>>> GetCategoriesAI();
    }
}