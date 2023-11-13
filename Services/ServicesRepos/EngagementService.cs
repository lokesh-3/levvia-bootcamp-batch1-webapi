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
    public class EngagementService : IEngagementSevice
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EngagementService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            _mapper = mapper;

        }

        public async Task<EngagementDTO> AddEngagement(EngagementDTO engagementDTO)
        {
            EngagementDTO engagement = new EngagementDTO();
            var eng = new Engagement();

            eng.ClientName = engagementDTO.ClientName;
            eng.ClientId = engagementDTO.ClientId;
            eng.EngagementStartDate = engagementDTO.EngagementStartDate;
            eng.EngagementEndDate = engagementDTO.EngagementEndDate;
            var user = await _unitOfWork.engagements.AddEngagement(eng);
            _unitOfWork.Complete();
            engagement.ClientId = user.ClientId;
            engagement.ClientName = user.ClientName;
            return engagement;
        }

        public async Task<List<EngagementDTO>> GetAllEngagements()
        {
            var getallengagements = new List<EngagementDTO>();
            var data = await _unitOfWork.engagements.GetAll();
            getallengagements = data.Select(x => _mapper.Map<EngagementDTO>(x)).ToList();
            return getallengagements;
        }

        public async Task<EngagementDTO> GetEngagementById(int engagementId)
        {
            var getEngagement = new EngagementDTO();
            var data = await _unitOfWork.engagements.GetById(engagementId);
            getEngagement = _mapper.Map<EngagementDTO>(data);
            return getEngagement;
        }
    }
}
    