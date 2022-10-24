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
        [HttpPost]
        public void Post([FromBody] ClienteViewModel vmCliente)
        {
            if (vmCliente == null)
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));

            ClienteDAO dao = new ClienteDAO();
            dao.cadastrarCliente(vmCliente);
        }
    }
}
