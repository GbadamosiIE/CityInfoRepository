using AutoMapper;
using CityInfo.Core.DTO;
using CityInfo.Core.IUnitOfWork;
using CityInfo.Core.Model;
using CityInfo.Core.Utilities;
using HotelManagement.Application.Utility;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CityInfo.Service.Services
{
    public class CityInfoServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        const int maxCitiesPageSize = 10;

        public CityInfoServices(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<IEnumerable<CityWithoutPointsOfInterestDto>>> GetCitiesAsync(string? name, 
            string? searchQuery, int pageNumber = 1, int pageSize = 10)
        {
            if (pageSize > maxCitiesPageSize)
            {
                pageSize = maxCitiesPageSize;
            }

            var GenericPaginationResponse = await _unitOfWork.cityInfoRepository.GetCitiesAsync(name, searchQuery, pageNumber, pageSize);

            //Response.Headers.Add("X-Pagination",
            //    JsonSerializer.Serialize(GenericPagination));

          var l =  _mapper.Map<IEnumerable<CityWithoutPointsOfInterestDto>>(GenericPaginationResponse);
            return Response<IEnumerable<CityWithoutPointsOfInterestDto>>.Success("dsdd",l);
        }
    }
}
