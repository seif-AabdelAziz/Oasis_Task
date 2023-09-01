using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDo.BL;
using ToDo.BL.Dto.Security;

namespace ToDo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ISecurityManager securityManager;

        public AccountController(ISecurityManager _securityManager)
        {
            securityManager = _securityManager;
        }

        [HttpPost]
        [Route("Register")]
        public ActionResult Register(RegisterDto register)
        {
            var request = securityManager.Register(register);
            if (request != null)
            {
                return BadRequest(request);
            }

            return NoContent();
        }

        [HttpPost]
        [Route("Login")]
        public ActionResult<TokenDto> Login(LoginDto login)
        {
            var request = securityManager.Login(login);
            if (request is null)
            {
                return BadRequest();
            }

            return request;
        }
    }
}
