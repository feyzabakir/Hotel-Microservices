using HotelAPI.Infrastructure;
using HotelAPI.Models;
using HotelAPI.Models.Dtos;
using HotelAPI.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using System.Reflection.Metadata;

namespace HotelAPI.Controllers
{
    public class HotelsController : CustomBasesController
    {
        private readonly IHotelService _hotelService;

        public HotelsController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }

        [HttpGet]
        public async Task<IActionResult> GetHotelsAsync()
        {
            var response = await _hotelService.GetHotelsAsync();
            return CreateActionResult(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetHotelByIdAsync(string id)
        {
            var objectId = new MongoDB.Bson.ObjectId(id);
            var response = await _hotelService.GetHotelByIdAsync(objectId);
            return CreateActionResult(response);

        }

        [HttpPost]
        public async Task<IActionResult> CreateHotelAsync(Hotel hotel)
        {
            var response = await _hotelService.CreateHotelAsync(hotel);
            return CreateActionResult(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotelContactAsync(string id)
        {
            var objectId = new MongoDB.Bson.ObjectId(id);
            var response = await _hotelService.DeleteHotelAsync(objectId);
            return CreateActionResult(response);
        }

    }
}
