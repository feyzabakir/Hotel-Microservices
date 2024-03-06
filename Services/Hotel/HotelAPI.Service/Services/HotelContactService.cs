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
    public class HotelContactService: IHotelContactService
    {
        private readonly IMongoCollection<HotelContact> _hotelContactCollection;

        public HotelContactService(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _hotelContactCollection = database.GetCollection<HotelContact>(databaseSettings.HotelContactCollectionName);
        }

        public async Task<Response<HotelContact>> AddHotelContactAsync(HotelContact hotelContact)
        {
            try
            {
                await _hotelContactCollection.InsertOneAsync(hotelContact);
                return Response<HotelContact>.Success(hotelContact, 201);
            }
            catch (Exception ex)
            {
                return Response<HotelContact>.Fail(new List<string> { ex.Message }, 500);
            }
        }

        public async Task<Response<NoContent>> DeleteHotelContactAsync(ObjectId hotelContactId)
        {
            try
            {
                var result = await _hotelContactCollection.DeleteOneAsync(contact => contact.Id == hotelContactId);
                if (result.DeletedCount == 0)
                    return Response<NoContent>.Fail(new List<string> { "Hotel contact not found" }, 404);

                return Response<NoContent>.Success(204);
            }
            catch (Exception ex)
            {
                return Response<NoContent>.Fail(new List<string> { ex.Message }, 500);
            }
        }

        public async Task<Response<IEnumerable<HotelContact>>> GetHotelsAsync()
        {
            try
            {
                var hotels = await _hotelContactCollection.Find(_ => true).ToListAsync();
                return Response<IEnumerable<HotelContact>>.Success(hotels, 200);
            }
            catch (Exception ex)
            {
                return Response<IEnumerable<HotelContact>>.Fail(new List<string> { ex.Message }, 500);
            }
        }
    }
}
