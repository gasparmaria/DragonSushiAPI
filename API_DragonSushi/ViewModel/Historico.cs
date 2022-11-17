using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace API_DragonSushi.ViewModel
{
    public class Historico
    {
        [DisplayFormat(DataFormatString = "{0:dd/MMM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? dataDelivery { get; set; }
        public decimal total{ get; set; }
        public string formaPag{ get; set; }
        public int numPedidos{ get; set; }
        public int idDelivery{ get; set; }
    }
}