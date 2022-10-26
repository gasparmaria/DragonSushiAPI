using API_DragonSushi.Metodos;
using API_DragonSushi.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API_DragonSushi.Controllers
{
    public class ComandaApiController : ApiController
    {
        // CADASTRAR COMANDA
        [HttpPost]
        public void Post([FromBody] Comanda comanda)
        {
            if (comanda == null)
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));

            ComandaDAO dao = new ComandaDAO();
            dao.cadastrarComanda(comanda);
        }

        // LISTAR COMANDAS
        [HttpGet]
        public IEnumerable ExibirComanda()
        {
            ComandaDAO dao = new ComandaDAO();
            var comanda = dao.ExibirComanda();
            return comanda;
        }

        // CONSULTAR COMANDA PELO NÚMERO
        [HttpGet]
        public Comanda ConsultarComanda(int num)
        {
            ComandaDAO dao = new ComandaDAO();
            var comanda = dao.ConsultarComanda(num);
            return comanda;
        }
    }
}
