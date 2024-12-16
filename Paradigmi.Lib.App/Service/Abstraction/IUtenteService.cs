using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paradigmi.Lib.App.Service
{
    public interface IUtenteService
    {
        public bool Registrazione(string nome, string cognome, string email, string password);
        public string Login(string email, string password); 

    }
}
