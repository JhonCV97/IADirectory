using Application.DTOs.ArtificialIntelligence;
using Application.DTOs.CategoriesAI;
using Application.DTOs.Role;
using Application.DTOs.User;
using AutoMapper;
using Domain.Models;

namespace Application.AutoMapper
{
    public class  ViewModelToDomainProfile : Profile
    {
        public ViewModelToDomainProfile()
        {
            CreateMap<UserDto, User>();
            CreateMap<UserPostDto, User>();
            CreateMap<RoleDto, Role>();

            CreateMap<CategoriesAIPostDto, CategoriesAI>();
            CreateMap<CategoriesAIDto, CategoriesAI>();

            CreateMap<ArtificialIntelligenceDto, ArtificialIntelligence>();
            CreateMap<ArtificialIntelligencePostDto, ArtificialIntelligence>();
        }
    }
}
