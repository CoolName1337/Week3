using Microsoft.AspNetCore.Mvc;
using LibraryApi.ViewModels;
using BusinessLayer.Dtos;
using BusinessLayer.Services;

namespace LibraryApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController(IBookService bookService) : ControllerBase
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
            var res = await bookService.GetByIdAsync(id);
            return Ok(res);
        }

        [HttpPost]
        public async Task<IActionResult> PostBookAsync([FromBody] CreateBookDto createBookDto)
        {
            var res = await bookService.CreateAsync(createBookDto);
            return Ok(res);
        }
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateBookAsync([FromRoute] int id, [FromBody] CreateBookDto createBookDto)
        {
            var res = await bookService.UpdateAsync(id, createBookDto);
            return Ok(res);
        }
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteBookAsync([FromRoute] int id)
        {
            await bookService.DeleteAsync(id);
            return NoContent();
        }
    }
}
