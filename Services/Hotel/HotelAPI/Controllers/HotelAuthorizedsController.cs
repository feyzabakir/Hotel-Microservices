using HotelAPI.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace HotelAPI.Controllers
{
    public class HotelAuthorizedsController : CustomBasesController
    {
        private readonly IHotelAuthorizedService _hotelAuthorizedService;

        public HotelAuthorizedsController(IHotelAuthorizedService hotelAuthorizedService)
        {
            _hotelAuthorizedService = hotelAuthorizedService;
        }
        [HttpGet("{hotelId}")]
        public async Task<IActionResult> GetHotelAuthorized(string hotelId)
        {
            var response = await _hotelAuthorizedService.GetHotelAuthorizedAsync(hotelId);
            return CreateActionResult(response);
        }

    }
}
