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
        public async Task<IActionResult> UpdateBookAsync([FromBody] UpdateBookDto updateBookDto)
        {
            var res = await bookService.UpdateAsync(updateBookDto);
            return Ok(res);
        }
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteBookAsync([FromRoute] int id)
        {
            await bookService.DeleteAsync(id);
            return NoContent();
        }
        [HttpGet]
        public async Task<IActionResult> GetBooksByFilterAsync([FromQuery] BookFilterDto bookFilterDto)
        {
            return Ok(await bookService.GetByFilterAsync(bookFilterDto));
        }
    }
}
