using Application.DTOs.ArtificialIntelligence;
using Application.DTOs.CategoriesAI;
using Application.DTOs.Role;
using Application.DTOs.User;
using AutoMapper;
using Domain.Models;

namespace Application.AutoMapper
{
    public class DomainToViewModelProfile : Profile
    {
        public DomainToViewModelProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<User, UserPostDto>();
            CreateMap<Role, RoleDto>();
            
            CreateMap<CategoriesAI, CategoriesAIPostDto>();
            CreateMap<CategoriesAI, CategoriesAIDto>();

            CreateMap<ArtificialIntelligence, ArtificialIntelligenceDto>();
            CreateMap<ArtificialIntelligence, ArtificialIntelligencePostDto>();
        }
    }
}
