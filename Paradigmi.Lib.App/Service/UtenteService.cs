using Microsoft.Extensions.Options;
using Paradigmi.Lib.Models;
using Paradigmi.Lib.Repository;
using Paradigmi.Lib.Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Paradigmi.Lib.App.Autenticatore;
using Paradigmi.Lib.App.Token;

namespace Paradigmi.Lib.App.Service
{
    public class UtenteService : IUtenteService
    {
        private readonly IUtente _utenteRepository;
        private GeneratoreToken _tokenService;

        public UtenteService(IUtente utenteRepository, IOptions<JwtAuthenticationOption> jwtAuthOptions)
        {
            _utenteRepository = utenteRepository;
            _tokenService = new GeneratoreToken(jwtAuthOptions);
        }

        public string Login(string email, string password)
        {
            if (_utenteRepository.ControlloCredenziali(email, password))
                return _tokenService.CreateToken(_utenteRepository.GetUtenteByEmail(email));
            return String.Empty;
        }

        public bool Registrazione(string nome, string cognome, string email, string password)
        {
            if (_utenteRepository.CheckEmail(email))
                return false;
            Utente utente = new Utente(nome, cognome, email, password);
            _utenteRepository.Aggiungi(utente);
            _utenteRepository.SaveChanges();
            return true;
        }
    }
}
