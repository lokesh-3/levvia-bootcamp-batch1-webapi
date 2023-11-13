using DTO;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interface
{
    public interface IUserService
    {
        Task CreateUser(UserDTO user);
        Task<List<UserDTO>> GetAllUsers();
        Task<List<UserDTO>> GetUsersByRole(string role);
        Task<UserDTO> GetUserById(int id);
    }
}
