using API_DragonSushi.Metodos;
using API_DragonSushi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API_DragonSushi.Controllers
{
    public class PedidoApiController : ApiController
    {
        [HttpPost]
        public void Post([FromBody] Pedido pedido)
        {
            if (pedido == null)
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));

            DAO dao = new DAO();
            dao.cadastrarPedido(pedido);
        }
    }
}
