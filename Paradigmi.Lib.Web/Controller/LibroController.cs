using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Paradigmi.Lib.App.Factories;
using Paradigmi.Lib.App.Models.DTO;
using Paradigmi.Lib.App.Models.Request;
using Paradigmi.Lib.App.Models.Response;
using Paradigmi.Lib.App.Service;
using Paradigmi.Lib.Models;
using Paradigmi.Lib.Repository;
using Paradigmi.Lib.Repository.Abstraction;

namespace Paradigmi.Lib.Web.Controller
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class LibroController : ControllerBase
    {
        private readonly ILibroService _libroService;
        private readonly ICategoria _categoriaRepository;

        public LibroController(ILibroService libroService, ICategoria categoriaRepository)
        {
            _libroService = libroService;
            _categoriaRepository = categoriaRepository;
        }

        [HttpPost]
        [Route("aggiungi")]
        public IActionResult AggiungiLibro([FromBody] AggiungiLibroRequest request)
        {
            var categorie = GetCategorie(request.Categorie);
            if (_libroService.AggiungiLibro(request.Nome, request.Autore, request.Editore, request.DataPubblicazione, categorie))
                return Ok(ResponseFactory.WithSuccess("Libro aggiunto con successo"));
            else
                return BadRequest();
        }

        [HttpPut]
        [Route("modifica")]
        public IActionResult ModificaLibro([FromBody] ModificaLibroRequest request)
        {
            var categorie = GetCategorie(request.Categorie);
            if (_libroService.ModificaLibro(request.Id, request.Nome, request.Autore, request.Editore, request.DataPubblicazione,
                categorie))
                return Ok(ResponseFactory.WithSuccess($"Libro con Id {request.Id} modificato con successo"));
            else
                return BadRequest();
        }

        [HttpDelete]
        [Route("elimina")]
        public IActionResult EliminaLibro([FromBody] EliminaLibroRequest request)
        {
            if (_libroService.EliminaLibro(request.Id))
                return Ok(ResponseFactory.WithSuccess($"Libro con Id {request.Id} eliminato con successo"));
            else
                return BadRequest();
        }

        [HttpPost]
        [Route("lista")]
        public IActionResult GetLibri([FromBody] GetLibriRequest request)
        {
            int totalNum = 0;
            var nome = request.Nome;
            var autore = request.Autore;
            var editore = request.Editore;
            var categoria = request.Categoria;
            if(nome=="string"||nome=="")
            {
                nome = null;
            }
            if (autore == "string" || autore == "")
            {
                autore = null;
            }
            if (editore == "string" || editore == "")
            {
                editore = null;
            }
            if (categoria == "string" || categoria == "")
            {
                categoria = null;
            }
            var libri = _libroService.GetLibri(nome, autore, editore, null, categoria, request.From, request.Size, out totalNum);
            var response = new GetLibriResponse();
            response.NumPagine = (int)Math.Ceiling((double)totalNum / request.Size);
            response.Libri = libri.Select(l => new LibroDto(l)).ToList();
            return Ok(ResponseFactory.WithSuccess(response));
        }
        private HashSet<Categoria> GetCategorie(HashSet<string> categorie)
        {
            var categorieCollection = new HashSet<Categoria>();
            foreach (string cat in categorie)
            {
                Categoria categoria = _categoriaRepository.Get(cat);
                if (categoria != null)
                    categorieCollection.Add(categoria);
            }
            return categorieCollection;
        }
    }
}
