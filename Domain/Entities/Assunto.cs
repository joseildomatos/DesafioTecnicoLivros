using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Desafio.Spassu.TJRJ.Domain.Entities
{
    public class Assunto : Base
    {     
        [Required(ErrorMessage = "Informe a descrição")]
        [MaxLength(100, ErrorMessage = "A descrição deve conter até 100 caracters")]
        [DisplayName("Descrição")]
        public string Descricao { get; set; }

        [DisplayName("Ativo")]
        public bool Ativo { get; set; }

    }
}
