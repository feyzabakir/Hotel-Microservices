using HotelAPI.Infrastructure;
using HotelAPI.Models;
using HotelAPI.Models.Dtos;
using HotelAPI.Service.Settings;
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

        public HotelService(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);

            var database = client.GetDatabase(databaseSettings.DatabaseName);

            _hotelCollection = database.GetCollection<Hotel>(databaseSettings.HotelCollectionName);

        }

        public async Task<Response<Hotel>> CreateHotelAsync(Hotel hotel)
        {
            try
            {
                await _hotelCollection.InsertOneAsync(hotel);
                return Response<Hotel>.Success(hotel, statusCode: 201);
            }
            catch (Exception ex)
            {
                return Response<Hotel>.Fail(new List<string> { ex.Message }, statusCode: 500);
            }
        }

        public async Task<Response<NoContent>> DeleteHotelAsync(string hotelId)
        {
            try
            {
                // hotelId stringini Guid türüne dönüştürmemiz gerekiyor
                Guid guidHotelId;
                if (!Guid.TryParse(hotelId, out guidHotelId))
                {
                    // Geçersiz UUID formatında hata işleme
                    return Response<NoContent>.Fail("Invalid hotelId format", statusCode: 400);
                }

                var deleteResult = await _hotelCollection.DeleteOneAsync(x => x.UUID == guidHotelId);

                if (deleteResult.DeletedCount > 0)
                    return Response<NoContent>.Success(statusCode: 204);

                return Response<NoContent>.Fail("Hotel not found", statusCode: 404);
            }
            catch (Exception ex)
            {
                return Response<NoContent>.Fail(new List<string> { ex.Message }, statusCode: 500);
            }
        }


    }
}
