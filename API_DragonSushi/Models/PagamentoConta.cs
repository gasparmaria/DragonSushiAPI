using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_DragonSushi.Models
{
    public class PagamentoConta
    {
        public int fkPag { get; set; }

        public int fkComanda { get; set; }
    }
}