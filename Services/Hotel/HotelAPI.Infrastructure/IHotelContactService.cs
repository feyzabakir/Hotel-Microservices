using HotelAPI.Models.Dtos;
using HotelAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelAPI.Infrastructure
{
    public interface IHotelContactService
    {
        Task<Response<List<HotelContact>>> GetHotelContactsByIdAsync(string contactId);
        Task<Response<HotelContact>> CreateHotelAsync(HotelContact contact);
        Task<Response<NoContent>> DeleteHotelAsync(string contactId);      
    }
}
