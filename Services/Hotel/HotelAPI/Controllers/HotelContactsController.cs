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

        [HttpGet("{contactId}")]
        public async Task<IActionResult> GetHotelContacts(string contactId)
        {
            var response = await _hotelContactService.GetHotelContactsByIdAsync(contactId);
            return CreateActionResult(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateHotelContact(HotelContact contact)
        {
            var response = await _hotelContactService.CreateHotelAsync(contact);
            return CreateActionResult(response);
        }

        [HttpDelete("{contactId}")]
        public async Task<IActionResult> DeleteHotel(string contactId)
        {
            var response = await _hotelContactService.DeleteHotelAsync(contactId);
            return CreateActionResult(response);
        }
    }
}
