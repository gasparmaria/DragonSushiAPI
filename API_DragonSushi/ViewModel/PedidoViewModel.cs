using API_DragonSushi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_DragonSushi.ViewModel
{
    public class PedidoViewModel
    {
        public Pedido Pedido { get; set; }

        public Produto Produto { get; set; }

        public Comanda Comanda { get; set; }

        public Delivery Delivery { get; set; }
    }
}