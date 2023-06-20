using Application.Common.Response;
using Application.DTOs.CategoriesAI;
using Application.Interfaces.CategoriesAI;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Application.Cqrs.CategoriesAI.Queries
{
    public class GetCategoriesAIByIdQuery : IRequest<ApiResponse<CategoriesAIDto>>
    {
        public int Id { get; set; }
    }
    public class GetCategoriesAIByIdQueryHandler : IRequestHandler<GetCategoriesAIByIdQuery, ApiResponse<CategoriesAIDto>>
    {
        private readonly ICategoriesAIService _categoriesAIService;
        public GetCategoriesAIByIdQueryHandler(ICategoriesAIService categoriesAIService)
        {
            _categoriesAIService = categoriesAIService;
        }

        public async Task<ApiResponse<CategoriesAIDto>> Handle(GetCategoriesAIByIdQuery request, CancellationToken cancellationToken)
        {
            return await _categoriesAIService.GetCategoriesAIById(request);
        }
    }
}
