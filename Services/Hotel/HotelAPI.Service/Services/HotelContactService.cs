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
    public class HotelContactService: IHotelContactService
    {
        private readonly IMongoCollection<HotelContact> _hotelContactCollection;

        public HotelContactService(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _hotelContactCollection = database.GetCollection<HotelContact>(databaseSettings.HotelContactCollectionName);
        }

        public async Task<Response<HotelContact>> CreateHotelAsync(HotelContact contact)
        {
            try
            {
                await _hotelContactCollection.InsertOneAsync(contact);
                return Response<HotelContact>.Success(contact, statusCode: 201);
            }
            catch (Exception ex)
            {
                return Response<HotelContact>.Fail(new List<string> { ex.Message }, statusCode: 500);
            }
        }

        public async Task<Response<NoContent>> DeleteHotelAsync(string hotelId)
        {
            try
            {
                // hotelId stringini Guid türüne dönüştürmemiz gerekiyor
                Guid guidHotelId = Guid.Parse(hotelId);

                var deleteResult = await _hotelContactCollection.DeleteOneAsync(x => x.UUID == guidHotelId);

                if (deleteResult.DeletedCount > 0)
                    return Response<NoContent>.Success(statusCode: 204);

                return Response<NoContent>.Fail("Hotel not found", statusCode: 404);
            }
            catch (FormatException)
            {
                // hotelId stringi geçersiz bir Guid formatında ise buraya düşer
                return Response<NoContent>.Fail("Invalid hotelId format", statusCode: 400);
            }
            catch (Exception ex)
            {
                return Response<NoContent>.Fail(new List<string> { ex.Message }, statusCode: 500);
            }
        }  

        public async Task<Response<List<HotelContact>>> GetHotelContactsByIdAsync(string contactId)
        {
            try
            {
                Guid id = Guid.Parse(contactId);

                var contacts = await _hotelContactCollection.Find(x => x.UUID == id).ToListAsync();

                return Response<List<HotelContact>>.Success(contacts, statusCode: 200);
            }
            catch (FormatException)
            {
                return Response<List<HotelContact>>.Fail("Invalid contactId format", statusCode: 400);
            }
            catch (Exception ex)
            {
                return Response<List<HotelContact>>.Fail(new List<string> { ex.Message }, statusCode: 500);
            }
        }
    }
}
