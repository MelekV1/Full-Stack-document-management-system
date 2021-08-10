using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoumentsManagementAPI.Domain.Models;
using DoumentsManagementAPI.Domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DoumentsManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this._categoryService = categoryService;
        }

        // GET: api/getAllCategories
        [HttpGet("getAllCategories")]
        public async Task<ActionResult<IEnumerable<Category>>> GetAllCategories()
        {
            var categories = await _categoryService.GetAllCategories();
            return Ok(categories);
        }

        // GET: api/getCategory/1
        [HttpGet("getCategory/{id}")]
        public async Task<Category> GetCategoryById(int id)
        {
            return await _categoryService.GetCategoryById(id);
        }

        // DELETE: api/deleteCategory/1
        [HttpDelete("deleteCategory/{id}")]
        public async Task<IActionResult> DeleteCategoryById(int id)
        {
            if (id == 0)
                return BadRequest();

            var category = await _categoryService.GetCategoryById(id);

            if (category == null)
                return NotFound();

            await _categoryService.DeleteCategory(category);

            return NoContent();
        }

        //POST : api/createCategory
        [HttpPost("createCategory")]
        public async Task<ActionResult<Category>> CreateMusic([FromBody] Category newCategory)
        {
            var returnCategory = await _categoryService.CreateCategory(newCategory);
            var result = await _categoryService.GetCategoryById(returnCategory.CategoryId);
            return Ok(result);
        }


    }
}
