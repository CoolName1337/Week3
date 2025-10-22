using LibraryApi.Dtos;
using Microsoft.AspNetCore.Mvc;
using BusinessLayer;

namespace LibraryApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController(IBookService bookService, IAuthorService authorService) : ControllerBase
    {
        [HttpGet("all")]
        public async Task<IActionResult> GetBooksAsync()
        {
            return Ok(await bookService.GetAllAsync());
        }
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetBookByIdAsync([FromRoute] int id)
        {
            var author = await bookService.GetByIdAsync(id);
            if (author is null)
                return NotFound();
            return Ok(author);
        }

        [HttpPost]
        public async Task<IActionResult> PostBookAsync([FromBody] BookDto bookDto)
        {
            if (await authorService.GetByIdAsync(bookDto.AuthorId) is null)
                return NotFound("Author is not found");

            await bookService.CreateAsync(bookDto.Title, bookDto.PublishedYear, bookDto.AuthorId);
            return NoContent();
        }
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateBookAsync([FromRoute] int id, [FromBody] BookDto bookDto)
        {
            if (await bookService.GetByIdAsync(id) is null)
                return NotFound("Book is not found");

            if (await authorService.GetByIdAsync(bookDto.AuthorId) is null)
                return NotFound("Author is not found");

            await bookService.UpdateAsync(id, bookDto.Title, bookDto.PublishedYear, bookDto.AuthorId);
            return NoContent();
        }
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteBookAsync([FromRoute] int id)
        {
            if (await bookService.GetByIdAsync(id) is null)
                return NotFound();

            await bookService.DeleteAsync(id);
            return NoContent();
        }
    }
}
