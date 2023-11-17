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

        public async Task<EngagementDTO> UpdateEngagement(EngagementDTO engagementDTO)
        {
            EngagementDTO engagement = new EngagementDTO();
            var eng = new Engagement();
            eng.ClientName = engagementDTO.ClientName;
            eng.ClientId = engagementDTO.ClientId;
            eng.EngagementStartDate = engagementDTO.EngagementStartDate;
            eng.EngagementEndDate = engagementDTO.EngagementEndDate;
            _unitOfWork.engagements.Update(eng);
            int row = _unitOfWork.Complete();
            if (row > 0)
            {
                AccountDetails accountDetails = new AccountDetails();
                accountDetails.ClientId = engagementDTO.ClientId;
                accountDetails.AccountNumber = engagementDTO.AccountNumber;
                accountDetails.AccountRecievable = engagementDTO.AccountRecievable;
                accountDetails.Cash = engagementDTO.Cash;
                accountDetails.OtherExpenses = engagementDTO.OtherExpenses;
                accountDetails.Inventory = engagementDTO.Inventory;
                accountDetails.AuditOutcomeId = engagementDTO.AuditOutcomeId;
                await _unitOfWork.accountDetails.AddAsync(accountDetails);
                _unitOfWork.Complete();
            }
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
            var clientAuditors = new List<ClientAuditorsDTO>();
            var data1 = await _unitOfWork.clientAuditors
            .GetAll()
            .ConfigureAwait(false);
            var filteredData = data1
            .Where(clientAuditors => clientAuditors.ClientId == engagementId)
            .Select(clientAuditors => clientAuditors.AuditorId)
            .ToList();

            getEngagement.Auditorids = filteredData;
            return getEngagement;
        }
    }
}
