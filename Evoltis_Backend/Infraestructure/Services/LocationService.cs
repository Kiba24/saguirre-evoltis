using Amazon.Util.Internal;
using Application.Common.Interfaces.Services;
using Application.Common.Models.Locations;
using Application.Locations.Dto;
using AutoMapper;
using System.Text.Json;

namespace Infraestructure.Services
{
    public class LocationService : ILocationService
    {
       
        private readonly IMapper _mapper;
        private readonly IFile _file;

        public LocationService(IFile file, IMapper mapper)
        {
            _file = file;
            _mapper = mapper;
        }

        public async Task<List<City>> GetCities(int provinceId)
        {
            var locations = await GetJsonFile();
            var province = locations.Find(x => x.Id == provinceId);
            return province.Cities;
        }

        public async Task<List<LocationModel>> GetJsonFile()
        {
            List<LocationModel> items;
            var filePath = $"./Resources/Locations/locations.json";

            if (!_file.Exists(filePath))
            {
                return null;
            }

            using (StreamReader reader = new StreamReader(filePath))
            {
                string json = reader.ReadToEnd();
                items = JsonSerializer.Deserialize<List<LocationModel>>(json);
            }
            return items;

        }

        public async Task<List<LocationDto>> GetProvinces()
        {
            var locations = await GetJsonFile();
            var provinces = _mapper.Map<List<LocationDto>>(locations);
            return provinces;
        }
    }
}
