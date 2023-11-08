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
    public class AudtiMasterService : IAudtiMasterService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public AudtiMasterService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            _mapper = mapper;

        }
        public  async Task<List<AuditMasterDTO>> GetAuditMaster()
        {

            var getallengagements = new List<AuditMasterDTO>();
           var  data= _unitOfWork.GetGenericRepository<AuditMaster>().GetAll().Result;
            getallengagements = data.Select(x => _mapper.Map<AuditMasterDTO>(x)).ToList();
            return getallengagements;
        }
    }
}
