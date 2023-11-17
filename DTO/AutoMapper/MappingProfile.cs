using AutoMapper;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.AutoMapper
{
    public class  MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Engagement, EngagementDTO>().ReverseMap();
            CreateMap<Country, CountryDTO>().ReverseMap();
            CreateMap<AuditMaster, AuditMasterDTO>().ReverseMap();
            CreateMap<AuditorsDetails, AuditorsDetailsDTO>().ReverseMap();
            CreateMap<Email, EmailDto>().ReverseMap();
            CreateMap<AuditReport, AuditReportDTO>().ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<AccountDetails, AccountDetailsDTO>().ReverseMap();
            CreateMap<ClientAuditors, ClientAuditorsDTO>().ReverseMap();
        }
    }
}
