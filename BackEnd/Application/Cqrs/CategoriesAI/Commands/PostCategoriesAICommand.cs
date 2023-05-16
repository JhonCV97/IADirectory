using Application.Common.Response;
using Application.DTOs.CategoriesAI;
using Application.Interfaces.CategoriesAI;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Cqrs.CategoriesAI.Commands
{
    public class PostCategoriesAICommand : IRequest<ApiResponse<CategoriesAIDto>>
    {
        public CategoriesAIPostDto CategoriesAIPostDto { get; set; }
    }

    public class PostCategoriesAICommandHandler : IRequestHandler<PostCategoriesAICommand, ApiResponse<CategoriesAIDto>>
    {
        private readonly ICategoriesAIService _categoriesAIService; 
        public PostCategoriesAICommandHandler(ICategoriesAIService categoriesAIService)
        {
            _categoriesAIService = categoriesAIService;
        }

        public async Task<ApiResponse<CategoriesAIDto>> Handle(PostCategoriesAICommand request, CancellationToken cancellationToken)
        {
            return await _categoriesAIService.AddCategoriesAI(request);
        }
    }

}
