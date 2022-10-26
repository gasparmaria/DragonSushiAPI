using API_DragonSushi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_DragonSushi.ViewModel
{
    public class PagamentoViewModel
    {
        public Pagamento Pagamento { get; set; }
        public FormaPg FormaPg { get; set; }
        public Comanda Comanda { get; set; }
    }
}