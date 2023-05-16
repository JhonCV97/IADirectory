using Application.Common.Response;
using Application.Cqrs.CategoriesAI.Commands;
using Application.DTOs.CategoriesAI;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces.CategoriesAI
{
    public interface ICategoriesAIService
    {
        Task<ApiResponse<CategoriesAIDto>> AddCategoriesAI(PostCategoriesAICommand request);
        Task<ApiResponse<List<CategoriesAIDto>>> GetCategoriesAI();
    }
}