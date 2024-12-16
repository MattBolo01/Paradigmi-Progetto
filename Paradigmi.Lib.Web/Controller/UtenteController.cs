using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Paradigmi.Lib.App.Factories;
using Paradigmi.Lib.App.Models.Request;
using Paradigmi.Lib.App.Models.Response;
using Paradigmi.Lib.App.Service;
using static System.Net.Mime.MediaTypeNames;

namespace Paradigmi.Lib.Web.Controller
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UtenteController : ControllerBase
    {
        private readonly IUtenteService _utenteService;

        public UtenteController(IUtenteService utenteService)
        {
            _utenteService = utenteService;
        }

        [HttpPost]
        [Route("registrazione")]
        public IActionResult Registrazione([FromBody] RegistrationRequest request)
        {
            var utente = request.ToEntity();
            if (_utenteService.Registrazione(utente.Nome, utente.Cognome, utente.Email, utente.Password))
            {
                var response = new RegistrationResponse();
                response.Utente = new App.Models.DTO.UtenteDto(utente);
                return Ok(ResponseFactory.WithSuccess(response));
            }
            else
                return BadRequest();
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            var token = _utenteService.Login(request.Email, request.Password);
            if (token == null)
                return BadRequest(ResponseFactory.WithError("Credenziali errate"));
            else
                return Ok(new LoginResponse(token));
        }
    }
}
