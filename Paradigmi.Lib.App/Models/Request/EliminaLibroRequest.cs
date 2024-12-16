using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paradigmi.Lib.App.Models.Request
{
    public class EliminaLibroRequest
    {
        public EliminaLibroRequest(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
