using HotelAPI.Models.Dtos;
using HotelAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelAPI.Infrastructure
{
    public interface IHotelAuthorizedService
    {
        Task<Response<List<HotelAuthorized>>> GetHotelAuthorizedAsync(string hotelId);
    }
}
