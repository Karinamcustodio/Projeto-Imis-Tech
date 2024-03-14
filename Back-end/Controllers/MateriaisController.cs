using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlanoBasico.Data;
using PlanoBasico.Models;

namespace PlanoBasico.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MateriaisController : ControllerBase
    {
        private readonly ApiContext _context;

        public MateriaisController(ApiContext context)
        {
            _context = context;
        }

        // GET: api/Materiais
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Material>>> GetMaterial()
        {
            return await _context.Materiais
                .Include(m => m.Categorias)
                .ToListAsync();
        }

        // GET: api/Materiais/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Material>> GetMaterial(int id)
        {
            var material = await _context.Materiais.FindAsync(id);

            if (material == null)
            {
                return NotFound();
            }

            return material;
        }

        // GET: api/Materiais/UltimoNumeroPorCategoria/5
        [HttpGet("UltimoNumeroPorCategoria/{categoriaId}")]
        public async Task<ActionResult<int>> GetUltimoNumeroPorCategoria(int categoriaId)
        {
            var ultimoMaterial = await _context.Materiais
                .Where(m => m.CategoriaId == categoriaId)
                .OrderByDescending(m => m.Id)
                .FirstOrDefaultAsync();

            if (ultimoMaterial == null)
            {
                return 0;
            }

            return ultimoMaterial.Id;
        }

        // PUT: api/Materiais/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMaterial(int id, Material material)
        {
            if (id != material.Id)
            {
                return BadRequest();
            }

            _context.Entry(material).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MaterialExists(id))
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

        // POST: api/Materiais
        [HttpPost]
        public async Task<ActionResult<Material>> PostMaterial(Material material)
        {
            material.CategoriaId = material.Categorias.Id;
            material.Categorias = await _context.Categorias.FirstOrDefaultAsync(m => m.Id == material.CategoriaId);

            _context.Materiais.Add(material);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMaterial", new { id = material.Id }, material);
        }

        // DELETE: api/Materiais/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMaterial(int id)
        {
            var material = await _context.Materiais.FindAsync(id);
            if (material == null)
            {
                return NotFound();
            }

            _context.Materiais.Remove(material);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MaterialExists(int id)
        {
            return _context.Materiais.Any(e => e.Id == id);
        }
    }
}
