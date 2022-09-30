using API_DragonSushi.Models;
using API_DragonSushi.Metodos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API_DragonSushi.Controllers
{
    public class UsuarioController : ApiController
    {
        // GET: api/Usuario
        [HttpPost]
        public void Post([FromBody] Usuario usuario, Pessoa pessoa)
        {
            if (usuario == null && pessoa == null)
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));

            var DAO = new DAO();
            DAO.spCadastrarUsuario(usuario, pessoa);
        }
    }
}
