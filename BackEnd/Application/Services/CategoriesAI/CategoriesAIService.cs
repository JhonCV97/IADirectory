using Application.Common.Response;
using Application.Cqrs.ArtificialIntelligence.Commands;
using Application.Cqrs.CategoriesAI.Commands;
using Application.Cqrs.CategoriesAI.Queries;
using Application.DTOs.ArtificialIntelligence;
using Application.DTOs.CategoriesAI;
using Application.Interfaces.CategoriesAI;
using Application.Interfaces.SaveImage;
using Application.Services.SaveImage;
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
        private readonly ISaveImage _saveImage;
        public CategoriesAIService(IUnitOfWork unitOfWork, IMapper autoMapper, ISaveImage saveImage)
        {
            _unitOfWork = unitOfWork;
            _autoMapper = autoMapper;
            _saveImage = saveImage;
        }

        public async Task<ApiResponse<List<CategoriesAIDto>>> GetCategoriesAI(GetCategoriesAIQuery request)
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
                response.Message = $"Error al consultar el registro, consulte con el administrador. { ex.Message } ";
            }

            return response;
        }

        public async Task<ApiResponse<CategoriesAIDto>> GetCategoriesAIById(GetCategoriesAIByIdQuery request)
        {
            var response = new ApiResponse<CategoriesAIDto>();

            try
            {
                response.Data = _autoMapper.Map<CategoriesAIDto>(await _unitOfWork.CategoriesAIRepository.GetById(request.Id));
                response.Result = true;
                response.Message = "OK";
            }
            catch (Exception ex)
            {
                response.Result = false;
                response.Message = $"Error al consultar el registro, consulte con el administrador. {ex.Message} ";
            }

            return response;
        }

        public async Task<ApiResponse<CategoriesAIDto>> AddCategoriesAI(PostCategoriesAICommand request)
        {
            var response = new ApiResponse<CategoriesAIDto>();

            try
            {
                await _saveImage.SaveImg(request.Image);
                var CategoriesAI = _autoMapper.Map<Domain.Models.CategoriesAI>(request.CategoriesAIPostDto);
                CategoriesAI.Image = request.Image.FileName;


                response.Data = _autoMapper.Map<CategoriesAIDto>(await _unitOfWork.CategoriesAIRepository.Add(CategoriesAI));
                response.Result = true;
                response.Message = "OK";
            }
            catch (Exception ex)
            {
                response.Result = false;
                response.Message = $"Error al Crear Usuario, consulte con el administrador. { ex.Message } ";
            }

            return response;
        }

        public async Task<ApiResponse<CategoriesAIDto>> UpdateCategoriesAI(PutCategoriesAICommand request)
        {
            var response = new ApiResponse<CategoriesAIDto>();
            try
            {
                await _saveImage.SaveImg(request.Image);

                var categoriesAIDto = new CategoriesAIDto
                {
                    Id = request.CategoriesAIDto.Id,
                    Name = request.CategoriesAIDto.Name,
                    Description = request.CategoriesAIDto.Description,
                    Image = request.Image.FileName,
                    Status = request.CategoriesAIDto.Status
                };

                response.Data = _autoMapper.Map<CategoriesAIDto>(await _unitOfWork.CategoriesAIRepository.Put(_autoMapper.Map<Domain.Models.CategoriesAI>(categoriesAIDto)));
                response.Result = true;
                response.Message = "OK";
            }
            catch (Exception ex)
            {
                response.Result = false;
                response.Message = $"Error al actualizar el registro, consulte con el administrador. {ex.Message} ";
                throw;
            }
            return response;
        }

        public async Task<ApiResponse<bool>> DeleteCategoriesAI(DeleteCategoriesAICommand request)
        {
            var response = new ApiResponse<bool>();
            try
            {
                var CategoriesAI = await _unitOfWork.CategoriesAIRepository.GetById(request.Id);

                response.Data = await _unitOfWork.CategoriesAIRepository.Delete(CategoriesAI);
                response.Result = true;
                response.Message = "Ok";
            }
            catch (Exception ex)
            {
                response.Result = false;
                response.Message = $"Error al eliminar el registro, consulte con el administrador. {ex.Message} ";
                throw;
            }
            return response;
        }

    }
}
