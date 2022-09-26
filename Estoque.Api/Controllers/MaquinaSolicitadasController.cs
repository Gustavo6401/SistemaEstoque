using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Estoque.Domain.Entities;
using Estoque.Infra.Contexto;

namespace Estoque.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaquinaSolicitadasController : ControllerBase
    {
        private readonly EstoqueContext _context;

        public MaquinaSolicitadasController(EstoqueContext context)
        {
            _context = context;
        }

        // GET: api/MaquinaSolicitadas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MaquinaSolicitada>>> GetMaquinaSolicitada()
        {
          if (_context.MaquinaSolicitada == null)
          {
              return NotFound();
          }
            return await _context.MaquinaSolicitada.ToListAsync();
        }

        // GET: api/MaquinaSolicitadas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MaquinaSolicitada>> GetMaquinaSolicitada(int id)
        {
          if (_context.MaquinaSolicitada == null)
          {
              return NotFound();
          }
            var maquinaSolicitada = await _context.MaquinaSolicitada.FindAsync(id);

            if (maquinaSolicitada == null)
            {
                return NotFound();
            }

            return maquinaSolicitada;
        }

        // PUT: api/MaquinaSolicitadas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMaquinaSolicitada(int id, MaquinaSolicitada maquinaSolicitada)
        {
            if (id != maquinaSolicitada.Id)
            {
                return BadRequest();
            }

            _context.Entry(maquinaSolicitada).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MaquinaSolicitadaExists(id))
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

        // POST: api/MaquinaSolicitadas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MaquinaSolicitada>> PostMaquinaSolicitada(MaquinaSolicitada maquinaSolicitada)
        {
          if (_context.MaquinaSolicitada == null)
          {
              return Problem("Entity set 'EstoqueContext.MaquinaSolicitada'  is null.");
          }
            _context.MaquinaSolicitada.Add(maquinaSolicitada);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMaquinaSolicitada", new { id = maquinaSolicitada.Id }, maquinaSolicitada);
        }

        // DELETE: api/MaquinaSolicitadas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMaquinaSolicitada(int id)
        {
            if (_context.MaquinaSolicitada == null)
            {
                return NotFound();
            }
            var maquinaSolicitada = await _context.MaquinaSolicitada.FindAsync(id);
            if (maquinaSolicitada == null)
            {
                return NotFound();
            }

            _context.MaquinaSolicitada.Remove(maquinaSolicitada);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MaquinaSolicitadaExists(int id)
        {
            return (_context.MaquinaSolicitada?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
