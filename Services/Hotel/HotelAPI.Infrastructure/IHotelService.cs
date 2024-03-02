using HotelAPI.Models;
using HotelAPI.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelAPI.Infrastructure
{
    public interface IHotelService
    {
        Task<Response<Hotel>> CreateHotelAsync(Hotel hotel);
        Task<Response<NoContent>> DeleteHotelAsync(string hotelId);
    }
}
