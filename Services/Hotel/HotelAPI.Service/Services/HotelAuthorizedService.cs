using HotelAPI.Infrastructure;
using HotelAPI.Models;
using HotelAPI.Models.Dtos;
using HotelAPI.Service.Settings;
using MongoDB.Driver;

namespace HotelAPI.Service.Services
{
    public class HotelAuthorizedService : IHotelAuthorizedService
    {
        private readonly IMongoCollection<HotelAuthorized> _hotelAuthorizedCollection;

        public HotelAuthorizedService(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _hotelAuthorizedCollection = database.GetCollection<HotelAuthorized>(databaseSettings.HotelAuthorizedCollectionName);
        }

        public async Task<Response<IEnumerable<HotelAuthorized>>> GetAllAuthorizedsAsync()
        {
            try
            {
                var authorizeds = await _hotelAuthorizedCollection.Find(_ => true).ToListAsync();
                return Response<IEnumerable<HotelAuthorized>>.Success(authorizeds, 200);
            }
            catch (Exception ex)
            {
                return Response<IEnumerable<HotelAuthorized>>.Fail(new List<string> { ex.Message }, 500);
            }
        }
    }
}
