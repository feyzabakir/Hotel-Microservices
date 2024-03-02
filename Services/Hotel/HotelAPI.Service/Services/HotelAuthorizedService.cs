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

        public async Task<Response<List<HotelAuthorized>>> GetHotelAuthorizedAsync(string hotelId)
        {
            var filter = Builders<HotelAuthorized>.Filter.Eq("HotelId", hotelId);
            var hotelAuthorizedList = await _hotelAuthorizedCollection.Find(filter).ToListAsync();

            if (hotelAuthorizedList == null || hotelAuthorizedList.Count == 0)
            {
                return Response<List<HotelAuthorized>>.Fail("Otel için yetkili personel bulunamadı", statusCode: 404);
            }

            return Response<List<HotelAuthorized>>.Success(hotelAuthorizedList, statusCode: 200);
        }
    }
}
