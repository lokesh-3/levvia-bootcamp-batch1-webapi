using AutoMapper;
using DataBase.UnitOfWork;
using DTO;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ServicesRepos
{
    public class EngagementService: IEngagementSevice
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EngagementService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            _mapper = mapper;

        }

        public async Task<List<EngagementDTO>> GetAllEngagements()
        {
            var getallengagements = new List<EngagementDTO>();
            var data = await _unitOfWork.engagements.GetAll();
            getallengagements = data.Select(x => _mapper.Map<EngagementDTO>(x)).ToList();
            return getallengagements;
        }
    }
}
