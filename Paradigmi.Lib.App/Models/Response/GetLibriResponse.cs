using Paradigmi.Lib.App.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paradigmi.Lib.App.Models.Response
{
    public class GetLibriResponse
    {
        public List<LibroDto> Libri { get; set; }
        public int NumPagine { get; set; }

        public GetLibriResponse(List<LibroDto> libri, int numPagine)
        {
            Libri = libri;
            NumPagine = numPagine;
        }

        public GetLibriResponse()
        {
            Libri = new List<LibroDto>();
            NumPagine = 0;
        }

    }
}
