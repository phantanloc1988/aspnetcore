using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyeStoreProject.Models;

namespace MyeStoreProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoaisController : ControllerBase
    {
        private readonly eStore20Context _context;

        public LoaisController(eStore20Context context)
        {
            _context = context;
        }

        // GET: api/Loais
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Loai>>> GetLoai()
        {
            return await _context.Loai.ToListAsync();
        }

        // GET: api/Loais/5
        [HttpGet("{id}")]
        [Authorize(Roles ="QuanTri")]
        public async Task<ActionResult<Loai>> GetLoai(int id)
        {
            var loai = await _context.Loai.FindAsync(id);

            if (loai == null)
            {
                return NotFound();
            }

            return loai;
        }

        // PUT: api/Loais/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLoai(int id, Loai loai)
        {
            if (id != loai.MaLoai)
            {
                return BadRequest();
            }

            _context.Entry(loai).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoaiExists(id))
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

        // POST: api/Loais
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Loai>> PostLoai(Loai loai)
        {
            _context.Loai.Add(loai);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLoai", new { id = loai.MaLoai }, loai);
        }

        // DELETE: api/Loais/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Loai>> DeleteLoai(int id)
        {
            var loai = await _context.Loai.FindAsync(id);
            if (loai == null)
            {
                return NotFound();
            }

            _context.Loai.Remove(loai);
            await _context.SaveChangesAsync();

            return loai;
        }

        private bool LoaiExists(int id)
        {
            return _context.Loai.Any(e => e.MaLoai == id);
        }
    }
}
