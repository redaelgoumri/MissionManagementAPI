using Microsoft.AspNetCore.Mvc;
using MissionManagementAPI.Application.Interfaces;
using MissionManagementAPI.Domain.Entities;

namespace MissionManagementAPI.Api.Controllers
{
    [ApiController]
    [Route("api")]
    public class PassengerController : ControllerBase
    {
        private readonly IPassengerService _passengerService;

        public PassengerController(IPassengerService passengerService)
        {
            _passengerService = passengerService;
        }

        [HttpGet("reservations/{id}/passengers")]
        public async Task<IActionResult> GetPassengers(int id)
        {
            var passengers = await _passengerService.GetPassengersByReservation(id);
            return Ok(passengers);
        }

        [HttpPost("reservations/{id}/passengers")]
        public async Task<IActionResult> AddPassenger(int id, [FromBody] Passenger passenger)
        {
            await _passengerService.AddPassenger(id, passenger);
            return Ok("Passenger added.");
        }

        [HttpDelete("passengers/{passengerId}")]
        public async Task<IActionResult> DeletePassenger(int passengerId)
        {
            await _passengerService.DeletePassenger(passengerId);
            return Ok("Passenger deleted.");
        }
    }
}
