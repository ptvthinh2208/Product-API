using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Product.Core.Entities;
using Product.Core.Interface;

namespace Product.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        public CategoryController(IUnitOfWork Uow)
        {
            _uow = Uow;
        }
        [HttpGet("get-all-category")]
        public async Task<ActionResult> Get()
        {
            var all_category = await _uow.CategoryRepository.GetAllAsync();
            if (all_category != null)
            {
                return Ok(all_category);
            }
            return BadRequest("Not Found");
        }
        [HttpGet("get-category-by-id/{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var category = await _uow.CategoryRepository.GetAsync(id);
            if (category == null)
                return BadRequest($"Not found this id = [{id}]");
            return Ok(category);
        }
        [HttpPost("add-new-category")]
        public async Task<ActionResult> post(Category category)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _uow.CategoryRepository.AddAsync(category);
                    return Ok(category);
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("update-exiting-category-by-id/{id}")]
        public async Task<ActionResult> put(int id, Category category)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var exiting_category = await _uow.CategoryRepository.GetAsync(id);
                    await _uow.CategoryRepository.UpdateAsync(id, exiting_category);
                    return Ok(exiting_category);
                }
                return BadRequest($"Category id [{id}] Not Found");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("delete-category-by-id/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var exiting_category = await _uow.CategoryRepository.GetAsync(id);
                if (exiting_category != null)
                {
                    await _uow.CategoryRepository.DeleteAsync(id);
                    return Ok($"This Category [{exiting_category.Name}] Is deleted ");
                }
                return BadRequest($"This Category [{exiting_category.Id}] Not Found");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
