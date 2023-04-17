using Smartproduct.Interface.Category;
using Smartproduct.Model.Category;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Smartproduct.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategory _repository;
        public CategoryController(ICategory repository)
        {
            _repository = repository;
        }

        [HttpGet("GetAll")]
        [SwaggerOperation]
        public async Task<ActionResult<IEnumerable<Category>>> GetAll()
        {
            var categories = await _repository.GetAllCategories();
            return Ok(categories);
        }

        [HttpGet("CheckIfCategoryExist/Name")]
        [SwaggerOperation]
        public async Task<ActionResult<bool>> CheckIfCategoryExist(string Name)
        {
            var category = await _repository.CheckIfCategoryExist(Name);
            return Ok(category);
        }

        [HttpGet("CheckIfCategoryCodeExist/{Name}")]
        [SwaggerOperation]
        public async Task<ActionResult<bool>> CheckIfCategoryCodeExist(string Name)
        {
            var category = await _repository.CheckIfCategoryCodeExist(Name);
            return Ok(category);
        }

        [HttpGet("Delete/{Model}")]
        [SwaggerOperation]
        public async Task<ActionResult<bool>> Delete(Category e)
        {
            return await _repository.Delete(e);
        }

        //api/Users/3
        [HttpGet("GetById/{Id}")]
        [SwaggerOperation]
        public async Task<ActionResult<Category>> GetBydId(int Id)
        {
            var category = await _repository.GetCategoryById(Id);
            return Ok(category);
        }

        [HttpPut("Update/{Model}")]
        [SwaggerOperation]
        public async Task<ActionResult<bool>> Update(Category e)
        {
            return await _repository.Put(e);
        }

        [HttpPost("Post/{Model}")]
        [SwaggerOperation]
        public async Task<ActionResult<bool>> Post(Category e)
        {
            return await _repository.Post(e);
        }
    }
}
