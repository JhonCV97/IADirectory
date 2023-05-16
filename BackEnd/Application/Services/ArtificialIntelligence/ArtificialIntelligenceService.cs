using Application.Common.Response;
using Application.Cqrs.ArtificialIntelligence.Commands;
using Application.DTOs.ArtificialIntelligence;
using Application.Interfaces.ArtificialIntelligence;
using AutoMapper;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.ArtificialIntelligence
{
    public class ArtificialIntelligenceService : IArtificialIntelligenceService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _autoMapper;
        public ArtificialIntelligenceService(IUnitOfWork unitOfWork, IMapper autoMapper)
        {
            _unitOfWork = unitOfWork;
            _autoMapper = autoMapper;
        }

        public async Task<ApiResponse<List<ArtificialIntelligenceDto>>> GetCategoriesAI()
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
                response.Message = $"Error al actualizar el registro, consulte con el administrador. { ex.Message } ";
            }

            return response;
        }

        public async Task<ApiResponse<ArtificialIntelligenceDto>> AddArtificialIntelligence(PostArtificialIntelligenceCommand request)
        {
            var response = new ApiResponse<ArtificialIntelligenceDto>();

            try
            {
                var ArtificialIntelligence = _autoMapper.Map<Domain.Models.ArtificialIntelligence>(request.ArtificialIntelligencePostDto);

                response.Data = _autoMapper.Map<ArtificialIntelligenceDto>(await _unitOfWork.ArtificialIntelligenceRepository.Add(ArtificialIntelligence));
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
