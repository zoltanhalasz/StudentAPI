using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentAPI.Models;

namespace StudentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentMarksController : ControllerBase
    {
        private readonly StudentDBContext _context;

        public StudentMarksController(StudentDBContext context)
        {
            _context = context;
        }

        // GET: api/StudentMarks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentMarks>>> GetStudentMarks()
        {
            return await _context.StudentMarks.ToListAsync();
        }

        // GET: api/StudentMarks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentMarks>> GetStudentMarks(int id)
        {
            var studentMarks = await _context.StudentMarks.FindAsync(id);

            if (studentMarks == null)
            {
                return NotFound();
            }

            return studentMarks;
        }

        // PUT: api/StudentMarks/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudentMarks(int id, StudentMarks studentMarks)
        {
            if (id != studentMarks.Id)
            {
                return BadRequest();
            }

            _context.Entry(studentMarks).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentMarksExists(id))
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

        // POST: api/StudentMarks
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<StudentMarks>> PostStudentMarks(StudentMarks studentMarks)
        {
            _context.StudentMarks.Add(studentMarks);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStudentMarks", new { id = studentMarks.Id }, studentMarks);
        }

        // DELETE: api/StudentMarks/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<StudentMarks>> DeleteStudentMarks(int id)
        {
            var studentMarks = await _context.StudentMarks.FindAsync(id);
            if (studentMarks == null)
            {
                return NotFound();
            }

            _context.StudentMarks.Remove(studentMarks);
            await _context.SaveChangesAsync();

            return studentMarks;
        }

        private bool StudentMarksExists(int id)
        {
            return _context.StudentMarks.Any(e => e.Id == id);
        }
    }
}
