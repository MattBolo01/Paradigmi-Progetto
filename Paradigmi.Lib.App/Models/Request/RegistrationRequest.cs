using Paradigmi.Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paradigmi.Lib.App.Models.Request
{
    public class RegistrationRequest
    {
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public Utente ToEntity()
        {
            return new Utente(Nome, Cognome, Email, Password);
        }
    }
}
