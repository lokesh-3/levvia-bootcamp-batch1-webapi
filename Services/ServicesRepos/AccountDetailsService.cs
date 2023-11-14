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
            //var accountDetails = new List<AccountDetailsDTO>();
            //var data = _unitOfWork.accountDetails.GetById(id);
            // var data = _unitOfWork.GetGenericRepository<AccountDetails>().GetById(id);
            //accountDetails = data.Select(x => _mapper.Map<AccountDetailsDTO>(x));
            try
            {
                var data = await _unitOfWork.accountDetails.GetById(id);
                var user = _mapper.Map<AccountDetailsDTO>(data);
                return user;
            }
            catch (Exception e)
            {

                throw;
            }
            
            
           // return _mapper.Map<AccountDetailsDTO>(data);       
        }
    }
}
