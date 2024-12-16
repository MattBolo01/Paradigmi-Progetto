using Paradigmi.Lib.Models;
using Paradigmi.Lib.Repository;
using Paradigmi.Lib.Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paradigmi.Lib.App.Service
{
    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoria _categoriaRepository;
        public CategoriaService(ICategoria categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }
        public bool AggiungiCategoria(string nome)
        {
            if (_categoriaRepository.Get(nome) != null)
                return false;
            Categoria categoria = new Categoria();
            categoria.Nome = nome;
            _categoriaRepository.Aggiungi(categoria);
            _categoriaRepository.SaveChanges();
            return true;
        }

        public bool EliminaCategoria(string nome)
        {
            Categoria categoria = _categoriaRepository.Get(nome);
            if (categoria != null && _categoriaRepository.GetLibri(nome).Count() == 0)
            {
                _categoriaRepository.Elimina(categoria.Nome);
                _categoriaRepository.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
