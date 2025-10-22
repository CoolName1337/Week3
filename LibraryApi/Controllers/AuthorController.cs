using Microsoft.AspNetCore.Mvc;
using BusinessLayer;
using LibraryApi.Dtos;

namespace LibraryApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthorController(IAuthorService authorService) : ControllerBase
    {

        [HttpGet("all")]
        public async Task<IActionResult> GetAuthorsAsync()
        {
            return Ok(await authorService.GetAllAsync());
        }
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetAuthorByIdAsync([FromRoute] int id)
        {
            var author = await authorService.GetByIdAsync(id);
            if(author is null)
                return NotFound();
            return Ok(author);
        }

        [HttpPost]
        public async Task<IActionResult> PostAuthorAsync([FromBody] AuthorDto authorDto)
        {
            await authorService.CreateAsync(authorDto.Name, authorDto.DateOfBirth);
            return NoContent();
        }
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateAuthorAsync([FromRoute] int id, [FromBody] AuthorDto authorDto)
        {
            if (await authorService.GetByIdAsync(id) is null)
                return NotFound();

            await authorService.UpdateAsync(id, authorDto.Name, authorDto.DateOfBirth);
            return NoContent();
        }
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteAuthorAsync([FromRoute] int id)
        {
            if (await authorService.GetByIdAsync(id) is null)
                return NotFound();

            await authorService.DeleteAsync(id);
            return NoContent();
        }
    }
}
