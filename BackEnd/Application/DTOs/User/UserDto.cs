using Application.DTOs.Role;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.User
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public RoleDto Role { get; set; }
    }
}
