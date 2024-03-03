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
    public class UnidadesMedida_MateriaisController : ControllerBase
    {
        private readonly ApiContext _context;

        public UnidadesMedida_MateriaisController(ApiContext context)
        {
            _context = context;
        }

        // GET: api/UnidadesMedida_Materiais
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UnidadeMedida_Material>>> GetUnidadeMedida_Material()
        {
            return await _context.UnidadeMedida_Material
                .Include(u => u.UnidadesMedida)
                .Include(u => u.Materiais)
                .ToListAsync();
        }

        // GET: api/UnidadesMedida_Materiais/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UnidadeMedida_Material>> GetUnidadeMedida_Material(int id)
        {
            var unidadeMedida_Material = await _context.UnidadeMedida_Material.FindAsync(id);

            if (unidadeMedida_Material == null)
            {
                return NotFound();
            }

            return unidadeMedida_Material;
        }

        // PUT: api/UnidadesMedida_Materiais/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUnidadeMedida_Material(int id, UnidadeMedida_Material unidadeMedida_Material)
        {
            if (id != unidadeMedida_Material.Id)
            {
                return BadRequest();
            }

            _context.Entry(unidadeMedida_Material).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UnidadeMedida_MaterialExists(id))
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

        // POST: api/UnidadesMedida_Materiais
        [HttpPost]
        public async Task<ActionResult<UnidadeMedida_Material>> PostUnidadeMedida_Material(UnidadeMedida_Material unidadeMedida_Material)
        {
            unidadeMedida_Material.UnidadesMedida = await _context.UnidadeMedida.FirstOrDefaultAsync(u => u.Id == unidadeMedida_Material.UnidadeMedidaId);
            unidadeMedida_Material.Materiais = await _context.Material.FirstOrDefaultAsync(u => u.Id == unidadeMedida_Material.MaterialId);

            _context.UnidadeMedida_Material.Add(unidadeMedida_Material);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUnidadeMedida_Material", new { id = unidadeMedida_Material.Id }, unidadeMedida_Material);
        }

        // DELETE: api/UnidadesMedida_Materiais/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUnidadeMedida_Material(int id)
        {
            var unidadeMedida_Material = await _context.UnidadeMedida_Material.FindAsync(id);
            if (unidadeMedida_Material == null)
            {
                return NotFound();
            }

            _context.UnidadeMedida_Material.Remove(unidadeMedida_Material);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UnidadeMedida_MaterialExists(int id)
        {
            return _context.UnidadeMedida_Material.Any(e => e.Id == id);
        }
    }
}
