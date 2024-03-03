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
    public class MateriaisController : ControllerBase
    {
        private readonly ApiContext _context;

        public MateriaisController(ApiContext context)
        {
            _context = context;
        }

        // GET: api/Materiais
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Material>>> GetMateriais()
        {
            return await _context.Material
                .Include(m => m.Categorias)
                .ToListAsync();
        }

        // GET: api/Materiais/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Material>> GetMaterial(int id)
        {
            var material = await _context.Material.FindAsync(id);

            if (material == null)
            {
                return NotFound();
            }

            return material;
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
            material.Categorias = await _context.Categoria.FirstOrDefaultAsync(m => m.Id == material.CategoriaId);

            _context.Material.Add(material);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMaterial", new { id = material.Id }, material);
        }

        // DELETE: api/Materiais/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMaterial(int id)
        {
            var material = await _context.Material.FindAsync(id);
            if (material == null)
            {
                return NotFound();
            }

            _context.Material.Remove(material);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MaterialExists(int id)
        {
            return _context.Material.Any(e => e.Id == id);
        }
    }
}
