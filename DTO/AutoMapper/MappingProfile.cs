﻿using AutoMapper;
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
            
        }
    }
}
