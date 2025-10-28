using Microsoft.AspNetCore.Mvc;
using LibraryApi.ViewModels;
using BusinessLayer.Dtos;
using BusinessLayer.Exceptions;
using BusinessLayer.Services;

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
            return Ok(author);
        }

        [HttpPost]
        public async Task<IActionResult> PostAuthorAsync([FromBody] CreateAuthorDto createAuthorDto)
        {
            var res = await authorService.CreateAsync(createAuthorDto);
            return Ok(res);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAuthorAsync([FromBody] UpdateAuthorDto updateAuthorDto)
        {
            var res = await authorService.UpdateAsync(updateAuthorDto);
            return Ok(res);
        }
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteAuthorAsync([FromRoute] int id)
        {
            await authorService.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> GetAuthorsByFilterAsync([FromQuery] AuthorFilterDto filter)
        {
            var authors = await authorService.GetByFilterAsync(filter);
            return Ok(authors);
        }

    }
}
