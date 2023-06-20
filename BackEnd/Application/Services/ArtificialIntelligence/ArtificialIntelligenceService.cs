using Application.Common.Response;
using Application.Cqrs.ArtificialIntelligence.Commands;
using Application.Cqrs.ArtificialIntelligence.Queries;
using Application.DTOs.ArtificialIntelligence;
using Application.DTOs.User;
using Application.Interfaces.ArtificialIntelligence;
using AutoMapper;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.AspNetCore.Http;
using System.IO;
using Application.Interfaces.SaveImage;
using Application.Cqrs.User.Queries;

namespace Application.Services.ArtificialIntelligence
{
    public class ArtificialIntelligenceService : IArtificialIntelligenceService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _autoMapper;
        private readonly ISaveImage _saveImage;
        public ArtificialIntelligenceService(IUnitOfWork unitOfWork, IMapper autoMapper, ISaveImage saveImage)
        {
            _unitOfWork = unitOfWork;
            _autoMapper = autoMapper;
            _saveImage = saveImage;
        }

        public async Task<ApiResponse<List<ArtificialIntelligenceDto>>> GetArtificialIntelligence(GetArtificialIntelligenceQuery request)
        {
            var response = new ApiResponse<List<ArtificialIntelligenceDto>>();
            try
            {
                response.Data = _autoMapper.Map<List<ArtificialIntelligenceDto>>(await _unitOfWork.ArtificialIntelligenceRepository.Get().ToListAsync());
               
                response.Result = true;
                response.Message = "OK";
            }
            catch (Exception ex)
            {
                response.Result = false;
                response.Message = $"Error al actualizar el registro, consulte con el administrador. {ex.Message} ";
            }
            return response;
        }

        public async Task<ApiResponse<ArtificialIntelligenceDto>> AddArtificialIntelligence(PostArtificialIntelligenceCommand request)
        {
            var response = new ApiResponse<ArtificialIntelligenceDto>();

            try
            {
                await _saveImage.SaveImg(request.Image);
                var ArtificialIntelligence = _autoMapper.Map<Domain.Models.ArtificialIntelligence>(request.ArtificialIntelligencePostDto);
                ArtificialIntelligence.Image = request.Image.FileName;

                response.Data = _autoMapper.Map<ArtificialIntelligenceDto>(await _unitOfWork.ArtificialIntelligenceRepository.Add(ArtificialIntelligence));
                response.Result = true;
                response.Message = "OK";
            }
            catch (Exception ex)
            {
                response.Result = false;
                response.Message = $"Error al Crear Usuario. {ex.Message} ";
            }
            return response;
        }

        public async Task<ApiResponse<ArtificialIntelligenceDto>> GetArtificialIntelligenceById(GetArtificialIntelligenceQueryById request)
        {
            var response = new ApiResponse<ArtificialIntelligenceDto>();

            try
            {
                response.Data = _autoMapper.Map<ArtificialIntelligenceDto>(await _unitOfWork.ArtificialIntelligenceRepository.GetById(request.Id));
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

        public async Task<ApiResponse<List<ArtificialIntelligenceDto>>> GetArtificialIntelligenceNew()
        {
            var response = new ApiResponse<List<ArtificialIntelligenceDto>>();
            try
            {
                response.Data = _autoMapper.Map<List<ArtificialIntelligenceDto>>(await _unitOfWork.ArtificialIntelligenceRepository.Get().Where(x => x.IsNew.Equals(true))
                                                                                                                                         .AsNoTracking()
                                                                                                                                         .ToListAsync());
                response.Result = true;
                response.Message = "OK";
               
            }
            catch (Exception ex)
            {
                response.Result = false;
                response.Message = $"Error al actualizar el registro, consulte con el administrador. {ex.Message} ";
            }
            return response;
        }

        public async Task<ApiResponse<ArtificialIntelligenceDto>> UpdateArtificialIntelligence(PutArtificialIntelligenceCommand request)
        {
            var response = new ApiResponse<ArtificialIntelligenceDto>();
            try
            {
                await _saveImage.SaveImg(request.Image);
                var artificialIntelligenceDto = new ArtificialIntelligenceDto
                {
                    Id = request.ArtificialIntelligencePostDto.Id,
                    Name = request.ArtificialIntelligencePostDto.Name,
                    Image = request.Image.FileName,
                    Description = request.ArtificialIntelligencePostDto.Description,
                    Url = request.ArtificialIntelligencePostDto.Url,
                    CategoriesAIId = request.ArtificialIntelligencePostDto.CategoriesAIId,
                    IsNew = request.ArtificialIntelligencePostDto.IsNew
                };

                response.Data = _autoMapper.Map<ArtificialIntelligenceDto>(await _unitOfWork.ArtificialIntelligenceRepository.Put(_autoMapper.Map<Domain.Models.ArtificialIntelligence>(artificialIntelligenceDto)));
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

        public async Task<ApiResponse<bool>> DeleteArtificialIntelligence(DeleteArtificialIntelligenceCommand request)
        {
            var response = new ApiResponse<bool>();
            try
            {
                var ArtificialIntelligence = await _unitOfWork.ArtificialIntelligenceRepository.GetById(request.Id);

                response.Data = await _unitOfWork.ArtificialIntelligenceRepository.Delete(ArtificialIntelligence);
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
