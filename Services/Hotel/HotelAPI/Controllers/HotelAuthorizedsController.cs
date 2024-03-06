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

        [HttpGet]
        public async Task<IActionResult> GetAllAuthorizedsAsync()
        {
            var response = await _hotelAuthorizedService.GetAllAuthorizedsAsync();
            return CreateActionResult(response);
        }
    }
}
