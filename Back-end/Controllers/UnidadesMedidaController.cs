using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Basico.Data;
using Basico.Models;

namespace Basico.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnidadesMedidaController : ControllerBase
    {
        private readonly ApiContext _context;

        public UnidadesMedidaController(ApiContext context)
        {
            _context = context;
        }

        // GET: api/UnidadesMedida
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UnidadeMedida>>> GetUnidadesMedida()
        {
            return await _context.UnidadeMedida.ToListAsync();
        }

        // GET: api/UnidadesMedida/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UnidadeMedida>> GetUnidadeMedida(int id)
        {
            var unidadeMedida = await _context.UnidadeMedida.FindAsync(id);

            if (unidadeMedida == null)
            {
                return NotFound();
            }

            return unidadeMedida;
        }

        // PUT: api/UnidadesMedida/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUnidadeMedida(int id, UnidadeMedida unidadeMedida)
        {
            if (id != unidadeMedida.Id)
            {
                return BadRequest();
            }

            _context.Entry(unidadeMedida).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UnidadeMedidaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/UnidadesMedida
        [HttpPost]
        public async Task<ActionResult<UnidadeMedida>> PostUnidadeMedida(UnidadeMedida unidadeMedida)
        {
            _context.UnidadeMedida.Add(unidadeMedida);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUnidadeMedida", new { id = unidadeMedida.Id }, unidadeMedida);
        }

        // DELETE: api/UnidadesMedida/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUnidadeMedida(int id)
        {
            var unidadeMedida = await _context.UnidadeMedida.FindAsync(id);
            if (unidadeMedida == null)
            {
                return NotFound();
            }

            _context.UnidadeMedida.Remove(unidadeMedida);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UnidadeMedidaExists(int id)
        {
            return _context.UnidadeMedida.Any(e => e.Id == id);
        }
    }
}
