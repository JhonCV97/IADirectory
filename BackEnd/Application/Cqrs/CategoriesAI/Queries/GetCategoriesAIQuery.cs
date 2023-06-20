using Application.Common.Response;
using Application.DTOs.CategoriesAI;
using Application.Interfaces.CategoriesAI;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Cqrs.CategoriesAI.Queries
{
    public class GetCategoriesAIQuery : IRequest<ApiResponse<List<CategoriesAIDto>>>
    {
    }
    public class GetCategoriesAIQueryHandler : IRequestHandler<GetCategoriesAIQuery, ApiResponse<List<CategoriesAIDto>>>
    {
        private readonly ICategoriesAIService _categoriesAIService;
        public GetCategoriesAIQueryHandler(ICategoriesAIService categoriesAIService)
        {
            _categoriesAIService = categoriesAIService;
        }

        public async Task<ApiResponse<List<CategoriesAIDto>>> Handle(GetCategoriesAIQuery request, CancellationToken cancellationToken)
        {
            return await _categoriesAIService.GetCategoriesAI(request);
        }
    }
}
