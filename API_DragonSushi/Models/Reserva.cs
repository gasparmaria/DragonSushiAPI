using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace API_DragonSushi.Models
{
    public class Reserva
    {
        public int idReserva { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime dataReserva { get; set; }
        public TimeSpan hora { get; set; }
        public int numPessoas { get; set; }
        public int fkPessoa { get; set; }
    }
}