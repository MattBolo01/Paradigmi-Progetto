using Microsoft.EntityFrameworkCore;
using Paradigmi.Lib.Contesto;
using Paradigmi.Lib.Models;
using Paradigmi.Lib.Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paradigmi.Lib.Repository
{
    /// <summary>
    /// Repository per la casse Utente
    /// </summary>
    public class UtenteRepository : GenericRepository<Utente>, IUtente
    {
        public UtenteRepository(MyDbContext context) : base(context)
        {
        }

        /// <summary>
        /// Verifica se l'email è già registrata
        /// </summary>
        /// <returns>True, False</returns>
        public bool CheckEmail(string email)
        {
            if (_ctx.Utenti.Any(u => u.Email.Equals(email)))
                return true;
            return false;
        }

        /// <summary>
        /// Verifica che email e password combacino
        /// </summary>
        /// <returns>True, False</returns>
        public bool ControlloCredenziali(string email, string password)
        {
            var utente = _ctx.Utenti.FirstOrDefault(u => u.Email.Equals(email) && u.Password.Equals(password));
            return utente != null;
        }

        /// <summary>
        /// Restituisce l'utente in base alla mail
        /// </summary>
        public Utente GetUtenteByEmail(string email)
        {
            return _ctx.Utenti.FirstOrDefault(u => u.Email.Equals(email));
        }
    }
}
