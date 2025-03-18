using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Writer.Api.Repositories.Interfaces;

namespace Writer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WritersController : ControllerBase
    {
        private readonly IWriterRepository _writerRepository;

        public WritersController(IWriterRepository writerRepository)
        {
            _writerRepository = writerRepository;
        }

        [HttpGet]
        public IActionResult GetAllWriters()
        {
            return Ok(_writerRepository.getAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetWriterDetail(int id)
        {
            var writer = _writerRepository.Get(id);
            if (writer == null)
            {
                return NotFound();
            }
            return Ok(writer);
        }

        [HttpPost]
        public IActionResult CreateWriter([FromBody] Models.Writer writer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var result = _writerRepository.Insert(writer);
            return CreatedAtAction(nameof(GetWriterDetail), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateWriter(int id, [FromBody] Models.Writer writer)
        {
            if (id != writer.Id)
            {
                return BadRequest("ID mismatch");
            }
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var existingWriter = _writerRepository.Get(id);
            if (existingWriter == null)
            {
                return NotFound();
            }
            
            var updatedWriter = _writerRepository.Update(writer);
            return Ok(updatedWriter);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteWriter(int id)
        {
            var deletedCount = _writerRepository.Delete(id);
            if (deletedCount == 0)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
