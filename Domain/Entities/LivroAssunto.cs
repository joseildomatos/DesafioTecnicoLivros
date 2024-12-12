using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Desafio.Spassu.TJRJ.Domain.Entities
{
    public class LivroAssunto
    {         
        [Key]
        public int LivroAssuntoId { get; set; }
        public int LivroId { get; set; }
        public virtual Livro Livro { get; set; }         
        public int AssuntoId { get; set; }
        public virtual Assunto Assunto { get; set; }
    }
}
