using Application.Common.Response;
using Application.DTOs.CategoriesAI;
using Application.Interfaces.CategoriesAI;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Application.Cqrs.CategoriesAI.Commands
{
    public class DeleteCategoriesAICommand : IRequest<ApiResponse<bool>>
    {
        public int Id { get; set; }
    }
    public class DeleteCategoriesAICommandHandler : IRequestHandler<DeleteCategoriesAICommand, ApiResponse<bool>>
    {
        private readonly ICategoriesAIService _categoriesAIService;
        public DeleteCategoriesAICommandHandler(ICategoriesAIService categoriesAIService)
        {
            _categoriesAIService = categoriesAIService;
        }

        public async Task<ApiResponse<bool>> Handle(DeleteCategoriesAICommand request, CancellationToken cancellationToken)
        {
            return await _categoriesAIService.DeleteCategoriesAI(request);
        }
    }
}
