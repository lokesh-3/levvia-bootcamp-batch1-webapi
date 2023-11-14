using AutoMapper;
using DataBase.Interface;
using DataBase.UnitOfWork;
using DTO;
using Entities;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services.ServicesRepos
{
    public class AuditOutcomeMasterService : IAuditOutcomeMasterService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AuditOutcomeMasterService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;

        }
        public async Task<List<AuditOutcomeMasterDTO>> GetAllAuditOutcomesMaster()
        {


            var auditOutcomeMasterDTO = new List<AuditOutcomeMasterDTO>();
            try
            {
                var data = await _unitOfWork.auditOutcomeMaster.GetAll();
                foreach (var item in data)
                {
                    auditOutcomeMasterDTO.Add(new AuditOutcomeMasterDTO { Id = item.Id, AuditOutcome = item.AuditOutcome });
                }

            }
            catch (Exception ex)
            {

                throw;
            }
            return auditOutcomeMasterDTO;
        }
    }
}
