using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DynamicCorsPolicy.Config.Data;
using DynamicCorsPolicy.Config.Models;

namespace DynamicCorsPolicy.Config.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AllowedOriginsController : ControllerBase
    {
        private readonly DynamicCorsPolicyConfigContext _context;

        public AllowedOriginsController(DynamicCorsPolicyConfigContext context)
        {
            _context = context;
        }

        // GET: api/AllowedOrigins
        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> GetAllowedOrigins()
        {
            return await _context.AllowedOrigins.Where(o=>o.Enabled).Select(s=>s.URL).ToListAsync();
        }

        // GET: api/AllowedOrigins/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AllowedOrigins>> GetAllowedOrigins(int id)
        {
            var allowedOrigins = await _context.AllowedOrigins.FindAsync(id);

            if (allowedOrigins == null)
            {
                return NotFound();
            }

            return allowedOrigins;
        }

        // PUT: api/AllowedOrigins/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAllowedOrigins(int id, AllowedOrigins allowedOrigins)
        {
            if (id != allowedOrigins.Id)
            {
                return BadRequest();
            }

            _context.Entry(allowedOrigins).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AllowedOriginsExists(id))
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

        // POST: api/AllowedOrigins
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<AllowedOrigins>> PostAllowedOrigins(AllowedOrigins allowedOrigins)
        {
            _context.AllowedOrigins.Add(allowedOrigins);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAllowedOrigins", new { id = allowedOrigins.Id }, allowedOrigins);
        }

        // DELETE: api/AllowedOrigins/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AllowedOrigins>> DeleteAllowedOrigins(int id)
        {
            var allowedOrigins = await _context.AllowedOrigins.FindAsync(id);
            if (allowedOrigins == null)
            {
                return NotFound();
            }

            _context.AllowedOrigins.Remove(allowedOrigins);
            await _context.SaveChangesAsync();

            return allowedOrigins;
        }

        private bool AllowedOriginsExists(int id)
        {
            return _context.AllowedOrigins.Any(e => e.Id == id);
        }
    }
}
