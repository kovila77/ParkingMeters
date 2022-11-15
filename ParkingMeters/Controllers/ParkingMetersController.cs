using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParkingMeters.DB;
using ParkingMeters.Models;

namespace ParkingMeters.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParkingMetersController : ControllerBase
    {
        private readonly ParkingContext _context;

        public ParkingMetersController(ParkingContext context)
        {
            _context = context;
        }

        // GET: api/ParkingMeters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ParkingMeterIdAddresDto>>> GetParkingMeters()
        {
            if (_context.ParkingMeters == null)
            {
                return NotFound();
            }

            return await _context.ParkingMeters
                .Select(x => new ParkingMeterIdAddresDto()
                {
                    Id = x.Id,
                    Address = x.Address,
                })
                .OrderBy(x => x.Address)
                .ToListAsync();
        }

        // POST: api/ParkingMeters
        [HttpPost]
        public async Task<ActionResult<ParkingMeterDto>> PostParkingMeter(ParkingMeterCreateDto parkingMeter)
        {
            if (_context.ParkingMeters == null)
            {
                return Problem("Entity set 'ParkingContext.ParkingMeters'  is null.");
            }

            var newParkingMeter = new ParkingMeter() { Address = parkingMeter.Address };

            _context.ParkingMeters.Add(newParkingMeter);
            await _context.SaveChangesAsync();

            return Ok(new ParkingMeterDto()
            {
                Id = newParkingMeter.Id,
                Address = newParkingMeter.Address,
                Status = newParkingMeter.Status,
                Usages = newParkingMeter.Usages,
            });
        }

        // PUT: api/ParkingMeter/Disable/5
        [HttpPut("Disable/{id}")]
        public async Task<IActionResult> DisableParkingMeter(int id)
        {
            if (_context.ParkingMeters == null)
            {
                return NotFound();
            }

            var parkingMeter = await _context.ParkingMeters.FirstOrDefaultAsync(x => x.Id == id);

            if (parkingMeter is null)
            {
                return NotFound();
            }

            parkingMeter.Status = false;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // PUT: api/ParkingMeter/Disable/5
        [HttpPut("Enable/{id}")]
        public async Task<IActionResult> EnableParkingMeter(int id)
        {
            if (_context.ParkingMeters == null)
            {
                return NotFound();
            }

            var parkingMeter = await _context.ParkingMeters.FirstOrDefaultAsync(x => x.Id == id);

            if (parkingMeter is null)
            {
                return NotFound();
            }

            parkingMeter.Status = true;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // PUT: api/ParkingMeters/5
        [HttpPut("AddUsage/{id}")]
        public async Task<IActionResult> AddUsageParkingMeter(int id)
        {
            if (_context.ParkingMeters == null)
            {
                return NotFound();
            }

            var parkingMeter = await _context.ParkingMeters.FirstOrDefaultAsync(x => x.Id == id);

            if (parkingMeter is null)
            {
                return NotFound();
            }

            if (parkingMeter.Status != true)
            {
                return BadRequest();
            }

            parkingMeter.Usages++;
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
