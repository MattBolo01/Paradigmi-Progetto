using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Paradigmi.Lib.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Paradigmi.Lib.App.Autenticatore;

namespace Paradigmi.Lib.App.Token
{
    /// <summary>
    /// Classe per la generazione del token di autenticazione
    /// </summary>
    public class GeneratoreToken
    {
        private readonly JwtAuthenticationOption _jwtOptions;

        public GeneratoreToken(IOptions<JwtAuthenticationOption> jwtAuthOps)
        {
            _jwtOptions = jwtAuthOps.Value;
        }
        public string CreateToken(Utente utente)
        {
            var claims = new List<Claim>
            {
                new Claim("IdUtente", utente.IdUtente.ToString()),
                new Claim(ClaimTypes.Email, utente.Email),
                new Claim(ClaimTypes.Name, utente.Nome)
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.Key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var securityToken = new JwtSecurityToken(_jwtOptions.Issuer,
                null,
                claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: credentials);

            var token = new JwtSecurityTokenHandler().WriteToken(securityToken);
            return token;
        }
    }
}
