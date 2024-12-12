using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Desafio.Spassu.TJRJ.Domain.Entities
{
    public class Autor : Base
    {     
        [Required(ErrorMessage = "Informe o nome")]
        [MaxLength(100, ErrorMessage = "O nome deve conter até 100 caracters")]
        [DisplayName("Nome")]
        public string Nome { get; set; }

        [DisplayName("Ativo")]
        public bool Ativo { get; set; }
    }
}
