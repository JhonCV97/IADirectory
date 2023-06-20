using Application.Common.Response;
using Application.Cqrs.CategoriesAI.Commands;
using Application.Cqrs.CategoriesAI.Queries;
using Application.DTOs.CategoriesAI;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces.CategoriesAI
{
    public interface ICategoriesAIService
    {
        Task<ApiResponse<CategoriesAIDto>> AddCategoriesAI(PostCategoriesAICommand request);
        Task<ApiResponse<List<CategoriesAIDto>>> GetCategoriesAI(GetCategoriesAIQuery request);
        Task<ApiResponse<CategoriesAIDto>> UpdateCategoriesAI(PutCategoriesAICommand request);
        Task<ApiResponse<bool>> DeleteCategoriesAI(DeleteCategoriesAICommand request);
        Task<ApiResponse<CategoriesAIDto>> GetCategoriesAIById(GetCategoriesAIByIdQuery request);
    }
}