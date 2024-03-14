using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlanoBasico.Data;
using PlanoBasico.Models;

namespace PlanoBasico.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoresMateriaisController : ControllerBase
    {
        private readonly ApiContext _context;

        public CoresMateriaisController(ApiContext context)
        {
            _context = context;
        }

        // GET: api/CoresMateriais
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CorMaterial>>> GetCoresMateriais()
        {
            return await _context.CoresMateriais
                .Include(c => c.Cores)
                .Include(c => c.Materiais)
                .ToListAsync();
        }

        // GET: api/CoresMateriais/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CorMaterial>> GetCorMaterial(int id)
        {
            var corMaterial = await _context.CoresMateriais.FindAsync(id);

            if (corMaterial == null)
            {
                return NotFound();
            }

            return corMaterial;
        }

        // PUT: api/CoresMateriais/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCorMaterial(int id, CorMaterial corMaterial)
        {
            if (id != corMaterial.Id)
            {
                return BadRequest();
            }

            _context.Entry(corMaterial).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CorMaterialExists(id))
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

        // POST: api/CoresMateriais
        [HttpPost]
        public async Task<ActionResult<CorMaterial>> PostCorMaterial(CorMaterial corMaterial)
        {
            corMaterial.CorId = corMaterial.Cores.Id;
            corMaterial.Cores = await _context.Cores.FirstOrDefaultAsync(c => c.Id == corMaterial.CorId);

            corMaterial.MaterialId = corMaterial.Materiais.Id;
            corMaterial.Materiais = await _context.Materiais.FirstOrDefaultAsync(c => c.Id == corMaterial.MaterialId);

            _context.CoresMateriais.Add(corMaterial);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCorMaterial", new { id = corMaterial.Id }, corMaterial);
        }

        // DELETE: api/CoresMateriais/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCorMaterial(int id)
        {
            var corMaterial = await _context.CoresMateriais.FindAsync(id);
            if (corMaterial == null)
            {
                return NotFound();
            }

            _context.CoresMateriais.Remove(corMaterial);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CorMaterialExists(int id)
        {
            return _context.CoresMateriais.Any(e => e.Id == id);
        }
    }
}
