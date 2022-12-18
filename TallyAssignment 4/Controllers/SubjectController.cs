using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using TallyAssignment_4.Models;

namespace TallyAssignment_4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly StudentDbContext _Db;

        public SubjectController(StudentDbContext db)
        {
            _Db = db;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Subject>>> GetSubjects()
        {
            return await _Db.subjects.ToListAsync();

        }
        [HttpPost]
        public async Task<ActionResult<Subject>> AddSubject(Subject subject)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            await _Db.subjects.AddAsync(subject);
            await _Db.SaveChangesAsync();
            return CreatedAtAction("GetSubjects", new { id = subject.SubjectId }, subject);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateById(int id, Subject subject)
        {
            if(subject == null || id != subject.SubjectId)
            {
                return BadRequest();
            }
            var sub = _Db.subjects.AsNoTracking().FirstOrDefault(u => u.SubjectId == id);
            sub.SubjectId = subject.SubjectId;
            sub.SubjectName = subject.SubjectName;
            sub.MaxMarks = subject.MaxMarks;
            sub.MarksObtained = subject.MarksObtained;
            sub.SubjectId = subject.SubjectId;

            _Db.subjects.Update(sub);
            await _Db.SaveChangesAsync();
            return Ok(sub);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(int id)
        {
           
                var dstud = await _Db.subjects.FirstOrDefaultAsync(u => u.StudentId == id);
                if (dstud == null)
                {
                    return NotFound();
                }
                _Db.subjects.Remove(dstud);
                await _Db.SaveChangesAsync();
                return NoContent();
           
        }
         

    }

}
