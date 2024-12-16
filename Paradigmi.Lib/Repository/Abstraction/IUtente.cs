using Paradigmi.Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paradigmi.Lib.Repository.Abstraction
{
    /// <summary>
    /// Interfaccia per la repository Utente
    /// </summary>
    public interface IUtente : IRepository<Utente>
    {
        bool CheckEmail(string email);
        bool ControlloCredenziali(string email, string password);
        Utente GetUtenteByEmail(string email);
    }
}
