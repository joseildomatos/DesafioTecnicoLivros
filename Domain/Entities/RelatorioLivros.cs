using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Desafio.Spassu.TJRJ.Domain.Entities
{
    public class RelatorioLivros
    {        
        public int AutorId { get; set; }
        public string AutorNome { get; set; }
        public string LivroNome { get; set; }
        public string AssuntoDescricao { get; set; }
    }
}
