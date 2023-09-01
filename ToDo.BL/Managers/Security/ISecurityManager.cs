using Microsoft.AspNetCore.Identity;
using ToDo.BL.Dto.Security;

namespace ToDo.BL;

public interface ISecurityManager
{
    IEnumerable<IdentityError>? Register(RegisterDto register);
    TokenDto? Login(LoginDto login);
}
