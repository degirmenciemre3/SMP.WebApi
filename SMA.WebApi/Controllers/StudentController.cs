using Microsoft.AspNetCore.Mvc;
using SMA.WebApi.Model;

namespace SMA.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentController : Controller
{
    private static List<Student> students = new List<Student>
    {
    new Student { Id = 1, FirstName = "John", LastName = "Doe", StudentNumber = "S12345" },
    new Student { Id = 2, FirstName = "Jane", LastName = "Smith", StudentNumber = "S67890" },
    // ... Diğer örnek öğrenciler
    };

    // GET: api/SMA
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(students);
    }

    // GET: api/SMA/5
    [HttpGet("{id}", Name = "Get")]
    public IActionResult Get(int id)
    {
        var student = students.Find(s => s.Id == id);

        if (student == null)
            return NotFound();

        return Ok(student);
    }

    // POST: api/SMA
    [HttpPost]
    public IActionResult Post([FromBody] Student student)
    {
        if (student == null)
            return BadRequest("Invalid student data");

        student.Id = students.Count + 1;
        students.Add(student);

        return CreatedAtAction(nameof(Get), new { id = student.Id }, student);
    }

    // PUT: api/SMA/5
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] Student updatedStudent)
    {
        var existingStudent = students.Find(s => s.Id == id);

        if (existingStudent == null)
            return NotFound();

        existingStudent.FirstName = updatedStudent.FirstName;
        existingStudent.LastName = updatedStudent.LastName;
        existingStudent.StudentNumber = updatedStudent.StudentNumber;

        return NoContent();
    }

    // DELETE: api/SMA/5
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var student = students.Find(s => s.Id == id);

        if (student == null)
            return NotFound();

        students.Remove(student);

        return NoContent();
    }
}
