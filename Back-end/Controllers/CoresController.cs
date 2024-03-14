using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlanoBasico.Data;
using PlanoBasico.Models;

namespace PlanoBasico.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoresController : ControllerBase
    {
        private readonly ApiContext _context;

        public CoresController(ApiContext context)
        {
            _context = context;
        }

        // GET: api/Cores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cor>>> GetCores()
        {
            return await _context.Cores.ToListAsync();
        }

        // GET: api/Cores/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cor>> GetCor(int id)
        {
            var cor = await _context.Cores.FindAsync(id);

            if (cor == null)
            {
                return NotFound();
            }

            return cor;
        }

        // PUT: api/Cores/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCor(int id, Cor cor)
        {
            if (id != cor.Id)
            {
                return BadRequest();
            }

            _context.Entry(cor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CorExists(id))
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

        // POST: api/Cores
        [HttpPost]
        public async Task<ActionResult<Cor>> PostCor(Cor cor)
        {
            _context.Cores.Add(cor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCor", new { id = cor.Id }, cor);
        }

        // DELETE: api/Cores/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCor(int id)
        {
            var cor = await _context.Cores.FindAsync(id);
            if (cor == null)
            {
                return NotFound();
            }

            _context.Cores.Remove(cor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CorExists(int id)
        {
            return _context.Cores.Any(e => e.Id == id);
        }
    }
}
