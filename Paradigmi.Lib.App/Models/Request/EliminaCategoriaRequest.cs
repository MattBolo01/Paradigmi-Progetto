using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paradigmi.Lib.App.Models.Request
{
    public class EliminaCategoriaRequest
    {
        public EliminaCategoriaRequest(string nome)
        {
            Nome = nome;
        }
        public string Nome { get; set; }
    }
}
