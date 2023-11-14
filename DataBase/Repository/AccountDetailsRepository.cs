using DataBase.Interface;
using Entities;

namespace DataBase.Repository
{
    public class AccountDetailsRepository : GenericRepository<AccountDetails>, IAccountDetailsRepository
    {
        public AccountDetailsRepository(ApplicationContext context) : base(context)
        {

        }
    }
}
