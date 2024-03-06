using HotelAPI.Infrastructure;
using HotelAPI.Models;
using HotelAPI.Models.Dtos;
using HotelAPI.Service.Settings;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HotelAPI.Service.Services
{
    public class HotelService : IHotelService
    {
        private readonly IMongoCollection<Hotel> _hotelCollection;
        private readonly IMongoCollection<HotelAuthorized> _hotelAuthorizedCollection;
        private readonly IMongoCollection<HotelContact> _hotelContactCollection;


        public HotelService(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);

            _hotelCollection = database.GetCollection<Hotel>(databaseSettings.HotelCollectionName);
            _hotelAuthorizedCollection = database.GetCollection<HotelAuthorized>(databaseSettings.HotelAuthorizedCollectionName);
            _hotelContactCollection = database.GetCollection<HotelContact>(databaseSettings.HotelContactCollectionName);

        }

        public async Task<Response<Hotel>> CreateHotelAsync(Hotel hotel)
        {

            try
            {
                // Otel bilgilerini ekleyin
                await _hotelCollection.InsertOneAsync(hotel);

                // Yetkili bilgilerini ekleyin
                foreach (var authorized in hotel.HotelAuthorizeds)
                {
                    authorized.HotelId = hotel.Id;
                    await _hotelAuthorizedCollection.InsertOneAsync(authorized);
                }

                // İletişim bilgilerini ekleyin
                foreach (var contact in hotel.HotelContacts)
                {
                    contact.HotelId = hotel.Id;
                    await _hotelContactCollection.InsertOneAsync(contact);
                }

                return Response<Hotel>.Success(hotel, 201);
            }
            catch (Exception ex)
            {
                return Response<Hotel>.Fail(new List<string> { ex.Message }, 500);
            }
        }

        public async Task<Response<NoContent>> DeleteHotelAsync(ObjectId hotelId)
        {
            try
            {
                var result = await _hotelCollection.DeleteOneAsync(h => h.Id == hotelId);
                if (result.DeletedCount == 0)
                    return Response<NoContent>.Fail(new List<string> { "Hotel not found" }, 404);

                return Response<NoContent>.Success(204);
            }
            catch (Exception ex)
            {
                return Response<NoContent>.Fail(new List<string> { ex.Message }, 500);
            }
        }

        public async Task<Response<Hotel>> GetHotelByIdAsync(ObjectId hotelId)
        {
            try
            {
                var hotel = await _hotelCollection.Find(h => h.Id == hotelId).FirstOrDefaultAsync();
                if (hotel == null)
                    return Response<Hotel>.Fail(new List<string> { "Hotel not found" }, 404);
                return Response<Hotel>.Success(hotel, 200);
            }
            catch (Exception ex)
            {
                return Response<Hotel>.Fail(new List<string> { ex.Message }, 500);
            }
        }

        public async Task<Response<IEnumerable<Hotel>>> GetHotelsAsync()
        {
            try
            {
                var hotels = await _hotelCollection.Find(_ => true).ToListAsync();
                return Response<IEnumerable<Hotel>>.Success(hotels, 200);
            }
            catch (Exception ex)
            {
                return Response<IEnumerable<Hotel>>.Fail(new List<string> { ex.Message }, 500);
            }
        }
    }
}
