﻿using Paradigmi.Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paradigmi.Lib.App.Models.DTO
{
    /// <summary>
    /// Input per la classe Libro
    /// </summary>
    public class LibroDto
    {
        public int IdLibro { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Autore { get; set; } = string.Empty;
        public string Editore { get; set; } = string.Empty;
        public DateTime DataPubblicazione { get; set; } = DateTime.MinValue;
        public ICollection<Categoria> Categorie { get; set; } = new HashSet<Categoria>();

        public LibroDto(Libro libro)
        {
            IdLibro = libro.IdLibro;
            Nome = libro.Nome;
            Autore = libro.Autore;
            Editore = libro.Editore;
            DataPubblicazione = libro.DataPubblicazione;
            Categorie = libro.Categorie;
        }
    }
}
