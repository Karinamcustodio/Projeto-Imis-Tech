using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlanoBasico.Data;
using PlanoBasico.Models;

namespace PlanoBasico.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SegmentosController : ControllerBase
    {
        private readonly ApiContext _context;

        public SegmentosController(ApiContext context)
        {
            _context = context;
        }

        // GET: api/Segmentos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Segmento>>> GetSegmentos()
        {
            return await _context.Segmentos.ToListAsync();
        }

        // GET: api/Segmentos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Segmento>> GetSegmento(int id)
        {
            var segmento = await _context.Segmentos.FindAsync(id);

            if (segmento == null)
            {
                return NotFound();
            }

            return segmento;
        }

        // PUT: api/Segmentos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSegmento(int id, Segmento segmento)
        {
            if (id != segmento.Id)
            {
                return BadRequest();
            }

            _context.Entry(segmento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SegmentoExists(id))
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

        // POST: api/Segmentos
        [HttpPost]
        public async Task<ActionResult<Segmento>> PostSegmento(Segmento segmento)
        {
            _context.Segmentos.Add(segmento);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSegmento", new { id = segmento.Id }, segmento);
        }

        // DELETE: api/Segmentos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSegmento(int id)
        {
            var segmento = await _context.Segmentos.FindAsync(id);
            if (segmento == null)
            {
                return NotFound();
            }

            _context.Segmentos.Remove(segmento);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SegmentoExists(int id)
        {
            return _context.Segmentos.Any(e => e.Id == id);
        }
    }
}
