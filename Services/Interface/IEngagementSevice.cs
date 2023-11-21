using DTO;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interface
{
    public interface IEngagementSevice
    {
        public Task<List<EngagementDTO>> GetAllEngagements();
        public Task<EngagementDTO> GetEngagementById(int id);
        public Task<EngagementDTO> AddEngagement( EngagementDTO engagementDTO);
        public Task<EngagementDTO> UpdateEngagement(EngagementDTO engagementDTO);
    }
}
