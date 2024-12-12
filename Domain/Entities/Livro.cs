using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Desafio.Spassu.TJRJ.Domain.Entities
{
    public class Livro : Base
    {     
        [Required(ErrorMessage = "Informe o título")]
        [MaxLength(100, ErrorMessage = "O título deve conter até 100 caracters")]
        [DisplayName("Título")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "Informe a editora")]
        [MaxLength(80, ErrorMessage = "a Editora deve conter até 100 caracters")]
        [DisplayName("Editora")]
        public string Editora { get; set; }

        [Required(ErrorMessage = "Informe a edição")]
        [MaxLength(80, ErrorMessage = "A edição deve conter até 100 caracters")]
        [DisplayName("Edição")]
        public string Edicao { get; set; }

        [DisplayFormat(DataFormatString = "{0:C0}")]
        [DisplayName("Preço Livro")]
        public decimal Preco { get; set; }

        [DisplayName("Ano publicação")]
        [MaxLength(4, ErrorMessage = "A edição deve conter até 4 caracters")]
        public string AnoPublicacao { get; set; }

        [DisplayName("Ativo")]
        public bool Ativo { get; set; }

        public virtual ICollection<Assunto> Assunto { get; set; }
        public virtual ICollection<Autor> Autor { get; set; }

    }
}
