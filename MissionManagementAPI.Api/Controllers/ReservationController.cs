using Microsoft.AspNetCore.Mvc;
using MissionManagementAPI.Application.Interfaces;
using MissionManagementAPI.Domain.Entities;

namespace MissionManagementAPI.Api.Controllers
{
    [ApiController]
    [Route("api/reservations")]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService _reservationService;
        //private readonly IReservationHistoryRepository _historyRepo;

        /*public ReservationController(IReservationService reservationService, IReservationHistoryRepository historyRepo)
        {
            _reservationService = reservationService;
            _historyRepo = historyRepo;
        }*/

        public ReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _reservationService.GetAllReservations();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var reservation = await _reservationService.GetReservationById(id);
            return reservation == null ? NotFound() : Ok(reservation);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Reservation reservation)
        {
            await _reservationService.CreateReservation(reservation);
            return CreatedAtAction(nameof(Get), new { id = reservation.IdDemande }, reservation);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Reservation reservation)
        {
            if (id != reservation.IdDemande) return BadRequest("Mismatched ID");

            await _reservationService.UpdateReservation(reservation);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _reservationService.DeleteReservation(id);
            return NoContent();
        }

        [HttpPost("{id}/submit")]
        public async Task<IActionResult> Submit(int id)
        {
            await _reservationService.SubmitReservation(id);
            return Ok("Demande soumise");
        }

        [HttpPost("{id}/approve-n1")]
        public async Task<IActionResult> ApproveN1(int id)
        {
            await _reservationService.ApproveByN1(id);
            return Ok("Validée par N+1");
        }

        [HttpPost("{id}/approve-daaj")]
        public async Task<IActionResult> ApproveDAAJ(int id)
        {
            await _reservationService.ApproveByDAAJ(id);
            return Ok("Validée par DAAJ");
        }

        [HttpPost("{id}/finalise")]
        public async Task<IActionResult> FinaliseParc(int id)
        {
            await _reservationService.FinaliseParParc(id);
            return Ok("Traitée par le parc auto");
        }

        [HttpPost("{id}/reject")]
        public async Task<IActionResult> Reject(int id, [FromBody] string motif)
        {
            await _reservationService.Reject(id, motif);
            return Ok("Demande rejetée");
        }
        /*
        [HttpGet("{id}/history")]
        public async Task<IActionResult> GetHistory(int id)
        {
            var history = await _historyRepo.GetByReservationIdAsync(id);
            return Ok(history);
        }*/
    }
}
