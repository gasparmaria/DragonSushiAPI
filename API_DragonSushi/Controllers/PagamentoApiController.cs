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
    public class PagamentoApiController : ApiController
    {
        //Efetuar pagamento
        [HttpPost]
        public void PagamentoComanda([FromBody] PagamentoViewModel vmPagamento)
        {
            if (vmPagamento == null)
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));

            PagamentoDAO dao = new PagamentoDAO();
            dao.PagamentoComanda(vmPagamento);
        }
    }
}
