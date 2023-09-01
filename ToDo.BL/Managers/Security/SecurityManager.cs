using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ToDo.BL.Dto.Security;

namespace ToDo.BL;

public class SecurityManager : ISecurityManager
{
    private readonly IConfiguration configuration;
    private readonly UserManager<IdentityUser> userManager;

    public SecurityManager(IConfiguration _configuration,
        UserManager<IdentityUser> _userManager)
    {
        userManager = _userManager;
        configuration = _configuration;
    }



    public IEnumerable<IdentityError>? Register(RegisterDto register)
    {
        var newAdmin = new IdentityUser
        {
            UserName = register.UserName,
            Email = register.Email
        };

        var creationResult = userManager.CreateAsync(newAdmin, register.Password).Result;
        if (!creationResult.Succeeded)
        {
            return creationResult.Errors;

        }

        var claims = new List<Claim> {
            new (ClaimTypes.NameIdentifier,newAdmin.Id),
            new (ClaimTypes.Role,"Admin")
        };

        var addClaims = userManager.AddClaimsAsync(newAdmin, claims).Result;
        if (!addClaims.Succeeded)
        {
            return addClaims.Errors;
        }


        return null;
    }

    public TokenDto? Login(LoginDto login)
    {
        IdentityUser? admin = userManager.FindByEmailAsync(login.Email).Result;
        if (admin == null)
        {
            return null;
        }

        bool passwordCorrect = userManager.CheckPasswordAsync(admin, login.Password).Result;
        if (!passwordCorrect)
        {
            return null;
        }

        List<Claim> claims = userManager.GetClaimsAsync(admin).Result.ToList();

        //Key
        string? keyString = configuration.GetSection("SecretKey").Value;
        byte[] keyBytes = Encoding.ASCII.GetBytes(keyString);
        SymmetricSecurityKey key = new SymmetricSecurityKey(keyBytes);

        //Hashing
        SigningCredentials signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

        //Token
        DateTime exp = DateTime.Now.AddMinutes(60);

        JwtSecurityToken newToken = new JwtSecurityToken
        (
            claims: claims,
            signingCredentials: signingCredentials,
            expires: exp

        );
        JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
        string token = handler.WriteToken(newToken);

        return new TokenDto
        {
            Token = token,
            exp = exp,
        };

    }
}
