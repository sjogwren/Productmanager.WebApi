using Smartproduct.Interface.Category;
using Smartproduct.Interface.Product;
using Smartproduct.Model.Category;
using Smartproduct.Model.Product;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Data;

namespace Smartproduct.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProduct _repository;
        public ProductController(IProduct repository)
        {
            _repository = repository;
        }

        [HttpGet("GetAll")]
        [SwaggerOperation]
        public async Task<ActionResult<IEnumerable<Product>>> GetAll()
        {
            var products = await _repository.GetAllProducts();
            return Ok(products);
        }

        [HttpGet("Delete/{ProductId}")]
        [SwaggerOperation]
        public async Task<ActionResult<bool>> Delete(int ProductId)
        {
            var product = await _repository.GetProductById(ProductId);
            
            return Ok(await _repository.Delete(product));
        }

        //api/Users/3
        [HttpGet("GetById/{Id}")]
        [SwaggerOperation]
        public async Task<ActionResult<Category>> GetBydId(int Id)
        {
            var product = await _repository.GetProductById(Id);
            return Ok(product);
        }


        [HttpGet("CheckIfProductExist/{Name}")]
        [SwaggerOperation]
        public async Task<ActionResult<bool>> CheckIfProductExist(string Name)
        {
            var product = await _repository.CheckIfProductExist(Name);
            return Ok(product);
        }

        [HttpPut("Update/{Model}")]
        [SwaggerOperation]
        public async Task<ActionResult> Update(Product e)
        {
            await _repository.Put(e);
            return Ok();
        }

        [HttpPost("Post/{Model}")]
        [SwaggerOperation]
        public async Task<ActionResult<Model.Product.Product>> Post(Product e)
        {
            return Ok(await _repository.Post(e));
        }


        [HttpPost("Bulkinsert/{Model}")]
        [SwaggerOperation]
        public async Task<ActionResult<bool>> Bulkinsert(List<Product> e)
        {
            return Ok(await _repository.Bulkinsert(e));
        }
    }
}
