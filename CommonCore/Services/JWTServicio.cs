using CommonCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Web.Services
{
    public class JWTServicio : IJWT
    {
        public JWTServicio(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        #region Propiedades
        public IConfiguration Configuration { get; }
        #endregion

        public JwtSecurityToken GeneralToken(ApplicationUser datoUsuario)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, datoUsuario.Email),
                new Claim(JwtRegisteredClaimNames.Email, datoUsuario.Email),
                new Claim(JwtRegisteredClaimNames.Gender, datoUsuario.Genero.ToString()),
                new Claim(JwtRegisteredClaimNames.FamilyName, datoUsuario.Apellidos),
                new Claim(JwtRegisteredClaimNames.GivenName, datoUsuario.Nombres),
                new Claim(Configuration["JWT:urlFoto"], datoUsuario.UrlFoto),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expiration = DateTime.UtcNow.AddDays(3000);

            JwtSecurityToken token = new JwtSecurityToken(
               issuer: Configuration["Dominio:validIssuer"],
               audience: Configuration["Dominio:validAudience"],
               claims: claims,
               expires: expiration,
               signingCredentials: creds);

            return token;
        }
    }
}
