using HotelAPI.Infrastructure;
using HotelAPI.Models;
using HotelAPI.Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace HotelAPI.Controllers
{
    public class HotelContactsController : CustomBasesController
    {
        private readonly IHotelContactService _hotelContactService;

        public HotelContactsController(IHotelContactService hotelContactService)
        {
            _hotelContactService = hotelContactService;
        }

        [HttpGet]
        public async Task<IActionResult> GetHotelsAsync()
        {
            var response = await _hotelContactService.GetHotelsAsync();
            return CreateActionResult(response);
        }

        [HttpPost]
        public async Task<IActionResult> AddHotelContactAsync(HotelContact hotelContact)
        {
            var response = await _hotelContactService.AddHotelContactAsync(hotelContact);
            return CreateActionResult(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotelContactAsync(string id)
        {
            var objectId = new MongoDB.Bson.ObjectId(id);
            var response = await _hotelContactService.DeleteHotelContactAsync(objectId);
            return CreateActionResult(response);
        }
    }
}
