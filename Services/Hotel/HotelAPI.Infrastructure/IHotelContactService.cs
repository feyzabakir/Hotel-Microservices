using HotelAPI.Models.Dtos;
using HotelAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace HotelAPI.Infrastructure
{
    public interface IHotelContactService
    {
        Task<Response<IEnumerable<HotelContact>>> GetHotelsAsync();

        Task<Response<HotelContact>> AddHotelContactAsync(HotelContact hotelContact);

        Task<Response<NoContent>> DeleteHotelContactAsync(ObjectId hotelContactId);
      
    }
}
