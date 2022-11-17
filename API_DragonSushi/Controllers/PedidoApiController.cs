using API_DragonSushi.Metodos;
using API_DragonSushi.Models;
using API_DragonSushi.ViewModel;
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
        // CADASTRAR PEDIDO
        [HttpPost]
        public void Post([FromBody] PedidoViewModel pedido)
        {
            if (pedido == null)
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));

            PedidoDAO dao = new PedidoDAO();
            dao.cadastrarPedido(pedido);
        }

        // EXCLUIR PEDIDO
        [HttpDelete]
        public void ExcluirPedido(int id)
        {
            PedidoDAO dao = new PedidoDAO();
            dao.ExcluirPedido(id);
        }

        [HttpGet]
        public List<PedidoViewModel> ConsultarPedidos(int comanda)
        {
            PedidoDAO dao = new PedidoDAO();
            var pedido = dao.ListarPedido(comanda);
            return pedido.ToList();
        }
    }
}
