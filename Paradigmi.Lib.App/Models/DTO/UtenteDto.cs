using Paradigmi.Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paradigmi.Lib.App.Models.DTO
{
    /// <summary>
    /// Input per la classe Utente
    /// </summary>
    public class UtenteDto
    {
        public UtenteDto(Utente utente)
        {
            this.IdUtente = IdUtente;
            this.Nome = utente.Nome;
            this.Cognome = utente.Cognome;
            this.Email = utente.Email;
            this.Password = utente.Password;
        }
        public int IdUtente { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Cognome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
