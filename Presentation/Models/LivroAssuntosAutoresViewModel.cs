using System.Collections.Generic;
using System;
using Desafio.Spassu.TJRJ.Domain.Response;

namespace Desafio.Spassu.TJRJ.MVC.Models
{
    public class LivroAssuntosAutoresViewModel
    {
        public int LivroId { get; set; }
        public string Titulo { get; set; }
        public string Editora { get; set; }
        public string Edicao { get; set; }
        public decimal Preco { get; set; }
        public string AnoPublicacao { get; set; }
        public bool Ativo { get; set; }
        public List<LivroAssuntosResponse> Assuntos { get; set; }
        public List<LivroAutoresResponse> Autores { get; set; }

    }
}
