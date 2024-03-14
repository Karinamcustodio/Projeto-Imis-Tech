using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlanoBasico.Data;
using PlanoBasico.Models;

namespace PlanoBasico.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoresProdutosController : ControllerBase
    {
        private readonly ApiContext _context;

        public CoresProdutosController(ApiContext context)
        {
            _context = context;
        }

        // GET: api/CoresProdutos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CorProduto>>> GetCoresProdutos()
        {
            return await _context.CoresProdutos
                .Include(c => c.Cores)
                .Include(c => c.Produtos)
                .ToListAsync();
        }

        // GET: api/CoresProdutos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CorProduto>> GetCorProduto(int id)
        {
            var corProduto = await _context.CoresProdutos.FindAsync(id);

            if (corProduto == null)
            {
                return NotFound();
            }

            return corProduto;
        }

        // PUT: api/CoresProdutos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCorProduto(int id, CorProduto corProduto)
        {
            if (id != corProduto.Id)
            {
                return BadRequest();
            }

            _context.Entry(corProduto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CorProdutoExists(id))
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

        // POST: api/CoresProdutos
        [HttpPost]
        public async Task<ActionResult<CorProduto>> PostCorProduto(CorProduto corProduto)
        {
            corProduto.CorId = corProduto.Cores.Id;
            corProduto.Cores = await _context.Cores.FirstOrDefaultAsync(c => c.Id == corProduto.CorId);

            corProduto.ProdutoId = corProduto.Produtos.Id;
            corProduto.Produtos = await _context.Produtos.FirstOrDefaultAsync(c => c.Id == corProduto.ProdutoId);

            _context.CoresProdutos.Add(corProduto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCorProduto", new { id = corProduto.Id }, corProduto);
        }

        // DELETE: api/CoresProdutos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCorProduto(int id)
        {
            var corProduto = await _context.CoresProdutos.FindAsync(id);
            if (corProduto == null)
            {
                return NotFound();
            }

            _context.CoresProdutos.Remove(corProduto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CorProdutoExists(int id)
        {
            return _context.CoresProdutos.Any(e => e.Id == id);
        }
    }
}
