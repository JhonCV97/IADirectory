using Application.Common.Response;
using Application.Cqrs.ArtificialIntelligence.Commands;
using Application.DTOs.ArtificialIntelligence;
using Application.Interfaces.ArtificialIntelligence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Application.DTOs.CategoriesAI;
using Application.Interfaces.CategoriesAI;
using Microsoft.AspNetCore.Http;

namespace Application.Cqrs.CategoriesAI.Commands
{
    public class PutCategoriesAICommand : IRequest<ApiResponse<CategoriesAIDto>>
    {
        public IFormFile Image { get; set; }
        public CategoriesAIDto CategoriesAIDto { get; set; }
    }
    public class PutCategoriesAICommandHandler : IRequestHandler<PutCategoriesAICommand, ApiResponse<CategoriesAIDto>>
    {
        private readonly ICategoriesAIService _categoriesAIService;
        public PutCategoriesAICommandHandler(ICategoriesAIService categoriesAIService)
        {
            _categoriesAIService = categoriesAIService;
        }

        public async Task<ApiResponse<CategoriesAIDto>> Handle(PutCategoriesAICommand request, CancellationToken cancellationToken)
        {
            return await _categoriesAIService.UpdateCategoriesAI(request);
        }
    }
}
