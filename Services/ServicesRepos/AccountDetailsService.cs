using AutoMapper;
using DataBase.UnitOfWork;
using DTO;
using Microsoft.EntityFrameworkCore;
using Services.Interface;

namespace Services.ServicesRepos
{
    public class AccountDetailsService : IAccountDetailsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public AccountDetailsService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            _mapper = mapper;

        }

        public async Task<List<AccountDetailsDTO>> GetAccountDetails(int id)
        {
            var accountDetails = new List<AccountDetailsDTO>();
            return accountDetails;
                //await _unitOfWork.engagements.Where(x => x.ClientId == id).ToListAsync();
        }
    }
}
