using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlanoBasico.Data;
using PlanoBasico.Models;

namespace PlanoBasico.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnidadesMedidasMateriaisController : ControllerBase
    {
        private readonly ApiContext _context;

        public UnidadesMedidasMateriaisController(ApiContext context)
        {
            _context = context;
        }

        // GET: api/UnidadesMedidasMateriais
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UnidadeMedidaMaterial>>> GetUnidadesMedidasMateriais()
        {
            return await _context.UnidadesMedidasMateriais
                .Include(u => u.UnidadesMedidas)
                .Include(u => u.Materiais)
                .ToListAsync();
        }

        // GET: api/UnidadesMedidasMateriais/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UnidadeMedidaMaterial>> GetUnidadeMedidaMaterial(int id)
        {
            var unidadeMedidaMaterial = await _context.UnidadesMedidasMateriais.FindAsync(id);

            if (unidadeMedidaMaterial == null)
            {
                return NotFound();
            }

            return unidadeMedidaMaterial;
        }

        // PUT: api/UnidadesMedidasMateriais/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUnidadeMedidaMaterial(int id, UnidadeMedidaMaterial unidadeMedidaMaterial)
        {
            if (id != unidadeMedidaMaterial.Id)
            {
                return BadRequest();
            }

            _context.Entry(unidadeMedidaMaterial).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UnidadeMedidaMaterialExists(id))
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

        // POST: api/UnidadesMedidasMateriais
        [HttpPost]
        public async Task<ActionResult<UnidadeMedidaMaterial>> PostUnidadeMedidaMaterial(UnidadeMedidaMaterial unidadeMedidaMaterial)
        {
            unidadeMedidaMaterial.UnidadeMedidaId = unidadeMedidaMaterial.UnidadesMedidas.Id;
            unidadeMedidaMaterial.UnidadesMedidas = await _context.UnidadesMedidas.FirstOrDefaultAsync(c => c.Id == unidadeMedidaMaterial.UnidadeMedidaId);

            unidadeMedidaMaterial.MaterialId = unidadeMedidaMaterial.Materiais.Id;
            unidadeMedidaMaterial.Materiais = await _context.Materiais.FirstOrDefaultAsync(c => c.Id == unidadeMedidaMaterial.MaterialId);

            _context.UnidadesMedidasMateriais.Add(unidadeMedidaMaterial);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUnidadeMedidaMaterial", new { id = unidadeMedidaMaterial.Id }, unidadeMedidaMaterial);
        }

        // DELETE: api/UnidadesMedidasMateriais/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUnidadeMedidaMaterial(int id)
        {
            var unidadeMedidaMaterial = await _context.UnidadesMedidasMateriais.FindAsync(id);
            if (unidadeMedidaMaterial == null)
            {
                return NotFound();
            }

            _context.UnidadesMedidasMateriais.Remove(unidadeMedidaMaterial);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UnidadeMedidaMaterialExists(int id)
        {
            return _context.UnidadesMedidasMateriais.Any(e => e.Id == id);
        }
    }
}
