using Smartproduct.Interface.Category;
using Smartproduct.Interface.File;
using Smartproduct.Model.Category;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Smartproduct.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IFile _repository;
        public FileController(IFile repository)
        {
            _repository = repository;
        }

        [HttpGet("GetAll")]
        [SwaggerOperation]
        public async Task<ActionResult<IEnumerable<Smartproduct.Model.File.File>>> GetAll()
        {
            var files = await _repository.GetAllFiles();
            return Ok(files);
        }

        //api/Users/3
        [HttpGet("GetById/{Id}")]
        [SwaggerOperation]
        public async Task<ActionResult<Smartproduct.Model.File.File>> GetBydId(int Id)
        {
            var file = await _repository.GetFileById(Id);
            return Ok(file);
        }

        [HttpPost("Insert/{Model}")]
        [SwaggerOperation]
        public async Task<ActionResult<bool>> Insert(Smartproduct.Model.File.File File)
        {
            return (await _repository.Insert(File));
        }
    }
}
