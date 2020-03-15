using CommonCore;
using System.IdentityModel.Tokens.Jwt;

namespace Web.Services
{
    interface IJWT
    {
        JwtSecurityToken GeneralToken(ApplicationUser datoUsuario); 
    }
}
