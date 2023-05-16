using Application.Common.Response;
using Application.Cqrs.CategoriesAI.Commands;
using Application.DTOs.CategoriesAI;
using Application.Interfaces.CategoriesAI;
using AutoMapper;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.CategoriesAI
{
    public class CategoriesAIService : ICategoriesAIService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _autoMapper;
        public CategoriesAIService(IUnitOfWork unitOfWork, IMapper autoMapper)
        {
            _unitOfWork = unitOfWork;
            _autoMapper = autoMapper;
        }

        public async Task<ApiResponse<List<CategoriesAIDto>>> GetCategoriesAI()
        {
            var response = new ApiResponse<List<CategoriesAIDto>>();

            try
            {
                response.Data = _autoMapper.Map<List<CategoriesAIDto>>(await _unitOfWork.CategoriesAIRepository.Get().ToListAsync());
                response.Result = true;
                response.Message = "OK";
            }
            catch (Exception ex)
            {
                response.Result = false;
                response.Message = $"Error al actualizar el registro, consulte con el administrador. { ex.Message } ";
            }

            return response;
        }

        public async Task<ApiResponse<CategoriesAIDto>> AddCategoriesAI(PostCategoriesAICommand request)
        {
            var response = new ApiResponse<CategoriesAIDto>();

            try
            {
                var CategoriesAI = _autoMapper.Map<Domain.Models.CategoriesAI>(request.CategoriesAIPostDto);

                response.Data = _autoMapper.Map<CategoriesAIDto>(await _unitOfWork.CategoriesAIRepository.Add(CategoriesAI));
                response.Result = true;
                response.Message = "OK";
            }
            catch (Exception ex)
            {
                response.Result = false;
                response.Message = $"Error al Crear Usuario. { ex.Message } ";
            }

            return response;
        }
    }
}
