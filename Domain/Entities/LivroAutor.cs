using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Desafio.Spassu.TJRJ.Domain.Entities
{
    public class LivroAutor
    {         
        [Key]
        public int LivroAutorId { get; set; }
        public int LivroId { get; set; }
        public virtual Livro Livro { get; set; }         
        public int AutorId { get; set; }
        public virtual Autor Autor { get; set; }
    }
}
