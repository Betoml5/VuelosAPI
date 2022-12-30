using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Vuelos.Models;

namespace Vuelos.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class VueloController : ControllerBase
    {
        private readonly VuelosContext _context;

        public VueloController(VuelosContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vuelo>>> GetVuelo()
        {
            return await _context.Vuelo.ToListAsync();
        }

        //create vuelo

        [HttpPost]
        public async Task<ActionResult<Vuelo>> PostVuelo(Vuelo vuelo)
        {
            _context.Vuelo.Add(vuelo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVuelo", new { id = vuelo.IdVuelo }, vuelo);
        }

        //get by id

        [HttpGet("{id}")]
        public async Task<ActionResult<Vuelo>> GetVuelo(int id)
        {
            var vuelo = await _context.Vuelo.FindAsync(id);

            if (vuelo == null)
            {
                return NotFound();
            }

            return vuelo;
        }


        private bool VueloExists(int id)
        {
          return _context.Vuelo.Any(e => e.IdVuelo == id);
        }
    }
}
