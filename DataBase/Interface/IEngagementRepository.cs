using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Interface
{
    public interface IEngagementRepository: IGenericRepository<Engagement>
    {

        public Task<Engagement> AddEngagement(Engagement  engagement);

    }
}
