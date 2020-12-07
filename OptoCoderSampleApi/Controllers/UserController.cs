using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OptoCoderSampleApi.Service.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OptoCoderSampleApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetUserInfo()
        {
            try
            {
                var res = await _service.GetUsersInfo();
                if (res != null)
                {

                    return Ok(res);
                }
                return StatusCode(StatusCodes.Status204NoContent);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
