using Application.Common.Models.Locations;
using Application.Locations.Dto;

namespace Application.Common.Interfaces.Services
{
    public interface ILocationService
    {
        public Task<List<LocationModel>> GetJsonFile();

        public Task<List<City>> GetCities(int provinceId);
        
        public Task<List<LocationDto>> GetProvinces();
    }
}
