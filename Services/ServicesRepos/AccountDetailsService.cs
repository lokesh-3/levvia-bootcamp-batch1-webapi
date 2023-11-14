using AutoMapper;
using DataBase.UnitOfWork;
using DTO;
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

        public async Task<AccountDetailsDTO> GetAccountDetails(int id)
        {
            var accountData = await _unitOfWork.accountDetails.GetById(id);
            var accountDetails = _mapper.Map<AccountDetailsDTO>(accountData);
            return accountDetails;
        }
    }
}
