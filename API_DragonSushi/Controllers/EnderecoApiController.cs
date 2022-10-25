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
    public class EnderecoApiController : ApiController
    {
        // CADASTRAR ENDEREÇO
        [HttpPost]
        public void Post([FromBody] EnderecoViewModel vmEndereco)
        {
            if (vmEndereco == null)
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));

            EnderecoDAO dao = new EnderecoDAO();
            dao.cadastrarEndereco(vmEndereco);
        }
    }
}
