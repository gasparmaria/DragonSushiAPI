using API_DragonSushi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_DragonSushi.ViewModel
{
    public class DeliveryViewModel
    {
        public Delivery Delivery { get; set; }

        public Pessoa Pessoa { get; set; }

        public Endereco Endereco { get; set; }

        public Comanda Comanda { get; set; }

        public Pagamento Pagamento { get; set; }

        public FormaPg FormaPg { get; set; }
    }
}