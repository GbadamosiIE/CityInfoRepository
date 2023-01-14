

using CityInfo.Core.Model;
using CityInfo.Core.Utilities;
using HotelManagement.Application.Utility;

namespace CityInfo.Core.IRepositories
{
    public interface ICityInfoRepository
    {
        Task<IEnumerable<City>> GetCitiesAsync();
        Task<GenericPagination<City>> GetCitiesAsync(
            string? name, string? searchQuery, int pageNumber, int pageSize);
        Task<City?> GetCityAsync(int cityId, bool includePointsOfInterest);
        Task<bool> CityExistsAsync(int cityId);
        Task<GenericPagination<PointOfInterest>> GetPointsOfInterestForCityAsync(int cityId, int pageNumber, int pageSize);
        Task<PointOfInterest?> GetPointOfInterestForCityAsync(int cityId, 
            int pointOfInterestId);
        Task<bool> AddPointOfInterestForCityAsync(int cityId, PointOfInterest pointOfInterest);
        void DeletePointOfInterest(PointOfInterest pointOfInterest);
        Task<bool> CityNameMatchesCityId(string? cityName, int cityId);
        Task<bool> SaveChangesAsync();
    }
}
