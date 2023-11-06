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
    public class CommanService : ICommanService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CommanService(IUnitOfWork unitOfWork)
        {
            _unitOfWork=unitOfWork ;
        }
        public async Task<List<CountryDTO>> GetAllCountry()
        {
            var countryDTOs = new List<CountryDTO>();
            var data = await _unitOfWork.country.GetAll();
           // countryDTOs = data.Select(x => _mapper.Map<CountryDTO>(x)).ToList();
            foreach (var item in data)
            {
                countryDTOs.Add(new CountryDTO { Id=item.Id,CountyName=item.CountyName,IsActive=item.IsActive});
            }

            return countryDTOs;
        }

    }

}
