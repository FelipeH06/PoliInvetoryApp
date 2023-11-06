using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PoliInventory.Application.DTOs;
using PoliInventory.Application.Features.Categories;

namespace PoliInventory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            IEnumerable<CategoryDto> categories = await _categoryService.GetAll();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            CategoryDto category = await _categoryService.GetById(id);
            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CategoryDto category)
        {
            category = await _categoryService.Add(category);
            return Ok(category);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _categoryService.Delete(id);
            return Ok();
        }

        [HttpPut()]
        public async Task<IActionResult> Put(CategoryDto category)
        {
            category = await _categoryService.Update(category);
            return Ok(category);
        }
    }
}
