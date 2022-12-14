using API_DragonSushi.Metodos;
using API_DragonSushi.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API_DragonSushi.Controllers
{
    public class ClienteApiController : ApiController
    {
        // CADASTRAR CLIENTE
        [HttpPost]
        public void Post([FromBody] ClienteViewModel vmCliente)
        {
            if (vmCliente == null)
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));

            ClienteDAO dao = new ClienteDAO();
            dao.cadastrarCliente(vmCliente);
        }

        // EDITAR CLIENTE
        [HttpPut]
        public void EditarCliente(int idPessoa, [FromBody] ClienteViewModel vmCliente)
        {
            ClienteDAO dao = new ClienteDAO();
            dao.EditarCliente(vmCliente);
        }

        // CONSULTAR CLIENTE PELO CPF
        [HttpGet]
        public ClienteViewModel Get(string cpf)
        {
            ClienteDAO dao = new ClienteDAO();
            var cliente = dao.ConsultarCliente(cpf);
            return cliente;
        }   
    }
}
