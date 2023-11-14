using DTO;

namespace Services.Interface
{
    public interface IAccountDetailsService
    {
        Task<AccountDetailsDTO> GetAccountDetails(int id);
    }
}
