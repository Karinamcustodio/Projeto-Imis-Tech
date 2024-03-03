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
    public class Cores_MateriaisController : ControllerBase
    {
        private readonly ApiContext _context;

        public Cores_MateriaisController(ApiContext context)
        {
            _context = context;
        }

        // GET: api/Cores_Materiais
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cor_Material>>> GetCor_Material()
        {
            return await _context.Cor_Material
                .Include(c => c.Cores)
                .Include(c => c.Materiais)
                .ToListAsync();
        }

        // GET: api/Cores_Materiais/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cor_Material>> GetCor_Material(int id)
        {
            var cor_Material = await _context.Cor_Material.FindAsync(id);

            if (cor_Material == null)
            {
                return NotFound();
            }

            return cor_Material;
        }

        // PUT: api/Cores_Materiais/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCor_Material(int id, Cor_Material cor_Material)
        {
            if (id != cor_Material.Id)
            {
                return BadRequest();
            }

            _context.Entry(cor_Material).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Cor_MaterialExists(id))
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

        // POST: api/Cores_Materiais
        [HttpPost]
        public async Task<ActionResult<Cor_Material>> PostCor_Material(Cor_Material cor_Material)
        {
            cor_Material.Cores = await _context.Cor.FirstOrDefaultAsync(u => u.Id == cor_Material.CorId);
            cor_Material.Materiais = await _context.Material.FirstOrDefaultAsync(u => u.Id == cor_Material.MaterialId);

            _context.Cor_Material.Add(cor_Material);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCor_Material", new { id = cor_Material.Id }, cor_Material);
        }

        // DELETE: api/Cores_Materiais/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCor_Material(int id)
        {
            var cor_Material = await _context.Cor_Material.FindAsync(id);
            if (cor_Material == null)
            {
                return NotFound();
            }

            _context.Cor_Material.Remove(cor_Material);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Cor_MaterialExists(int id)
        {
            return _context.Cor_Material.Any(e => e.Id == id);
        }
    }
}
