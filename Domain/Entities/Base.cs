using Entities.Notifications;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Desafio.Spassu.TJRJ.Domain.Entities
{
    public class Base : Notifies
    {
        [Key]
        [DisplayName("Código")]
        public int Id { get; set; }
        
    }
}
