using AutoMapper;
using DataBase.UnitOfWork;
using DTO;
using Entities;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ServicesRepos
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task CreateUser(UserDTO user)
        {
            User createUser = new User()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                FullName = user.FullName,
                Email = user.Email,
                Role = user.Role,
            };

            await _unitOfWork.users.AddAsync(createUser);
            _unitOfWork.Complete();
        }

        public async Task<List<UserDTO>> GetAllUsers()
        {
            var users = new List<UserDTO>();
            var data = await _unitOfWork.users.GetAll();
            users = data.Select(x => _mapper.Map<UserDTO>(x)).ToList();
            return users;
        }

        public async Task<List<UserDTO>> GetUsersByRole(string role)
        {
            var users = new List<UserDTO>();
            var data = await _unitOfWork.users.GetAll();
            users = data.Select(x => _mapper.Map<UserDTO>(x)).Where(x=>x.Role == role).ToList();
            return users;
        }

        public async Task<UserDTO> GetUserById(int id)
        {
            var data = await _unitOfWork.users.GetById(id);
            var user = _mapper.Map<UserDTO>(data);
            return user;
        }
    }
}
