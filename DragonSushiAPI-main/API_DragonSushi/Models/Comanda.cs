using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_DragonSushi.Models
{
    public class Comanda
    {
        public int idComanda { get; set; }
        public int numMesa { get; set; }
        public bool statusComanda { get; set; }
    }
}