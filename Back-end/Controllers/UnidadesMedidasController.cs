using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlanoBasico.Data;
using PlanoBasico.Models;

namespace PlanoBasico.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnidadesMedidasController : ControllerBase
    {
        private readonly ApiContext _context;

        public UnidadesMedidasController(ApiContext context)
        {
            _context = context;
        }

        // GET: api/UnidadesMedidas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UnidadeMedida>>> GetUnidadesMedidas()
        {
            return await _context.UnidadesMedidas.ToListAsync();
        }

        // GET: api/UnidadesMedidas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UnidadeMedida>> GetUnidadeMedida(int id)
        {
            var unidadeMedida = await _context.UnidadesMedidas.FindAsync(id);

            if (unidadeMedida == null)
            {
                return NotFound();
            }

            return unidadeMedida;
        }

        // PUT: api/UnidadesMedidas/5
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

        // POST: api/UnidadesMedidas
        [HttpPost]
        public async Task<ActionResult<UnidadeMedida>> PostUnidadeMedida(UnidadeMedida unidadeMedida)
        {
            _context.UnidadesMedidas.Add(unidadeMedida);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUnidadeMedida", new { id = unidadeMedida.Id }, unidadeMedida);
        }

        // DELETE: api/UnidadesMedidas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUnidadeMedida(int id)
        {
            var unidadeMedida = await _context.UnidadesMedidas.FindAsync(id);
            if (unidadeMedida == null)
            {
                return NotFound();
            }

            _context.UnidadesMedidas.Remove(unidadeMedida);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UnidadeMedidaExists(int id)
        {
            return _context.UnidadesMedidas.Any(e => e.Id == id);
        }
    }
}
