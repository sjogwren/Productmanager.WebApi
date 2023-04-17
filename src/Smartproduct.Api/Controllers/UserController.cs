using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Smartproduct.Interface.User;
using Smartproduct.Model.User;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Smartproduct.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IExternalUser _externalUser;
        public UserController(IExternalUser externalUser)
        {
            _externalUser = externalUser;
        }

        #region ====================  User  ====================
        [HttpGet("GetByUsername/{username}")]
        [SwaggerOperation]
        public async Task<ActionResult<ExternalUser>> GetByUsername(string username)
        {
            return await _externalUser.FindByNameAsync(username);
        }

        [HttpGet("GetByUserId/{userId}")]
        [SwaggerOperation]
        public async Task<ActionResult<ExternalUser>> GetByUserId(int userId)
        {
            return await _externalUser.FindByIdAsync(userId);
        }

        [HttpPost("CreateAsync/{Model}")]
        [SwaggerOperation]
        public async Task<ActionResult<bool>> CreateAsync(ExternalUser user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            user.NormalizedUserName = user.Email;
            user.NormalizedEmail = user.Email;
            return await _externalUser.CreateAsync(user);
        }


        [HttpPut("Put/{Model}")]
        [SwaggerOperation]
        public async Task<ActionResult<bool>> Put(ExternalUser user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return await _externalUser.UpdateAsync(user);
        }

        [HttpGet("CheckIfEmailExist/{email}")]
        [SwaggerOperation]
        public async Task<ActionResult<bool>> CheckIfEmailExist(string email)
        {
            return await _externalUser.CheckIfEmailExist(email);
        }

        #endregion
    }
}
