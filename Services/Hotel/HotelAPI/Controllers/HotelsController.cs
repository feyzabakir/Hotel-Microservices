using HotelAPI.Infrastructure;
using HotelAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelAPI.Controllers
{
    public class HotelsController : CustomBasesController
    {
        private readonly IHotelService _hotelService;

        public HotelsController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateHotel(Hotel hotel)
        {
            var response = await _hotelService.CreateHotelAsync(hotel);
            return CreateActionResult(response);
        }

        [HttpDelete("{hotelId}")]
        public async Task<IActionResult> DeleteHotel(string hotelId)
        {
            var response = await _hotelService.DeleteHotelAsync(hotelId);
            return CreateActionResult(response);
        }
    }
}
