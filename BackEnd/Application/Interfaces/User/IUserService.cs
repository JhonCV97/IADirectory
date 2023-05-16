using Application.Common.Response;
using Application.Cqrs.User.Commands;
using Application.DTOs.User;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces.User
{
    public interface IUserService
    {
        Task<ApiResponse<UserDto>> AddUser(PostUserCommand request);
        Task<ApiResponse<List<UserDto>>> GetUsers();
    }
}