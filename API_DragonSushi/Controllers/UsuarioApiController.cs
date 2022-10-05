using API_DragonSushi.Metodos;
using API_DragonSushi.ViewModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;

namespace API_DragonSushi.Controllers
{
    public class UsuarioApiController : ApiController
    {
        // GET: api/UsuarioApi
        [HttpGet]
        public IEnumerable ListarUsuarios()
        {
           
                UsuarioViewModel vmUsuario = new UsuarioViewModel();
                var listaUsuarios = vmUsuario.listarUsuarios();

                return listaUsuarios;


        }

        [HttpPost]
        public void Post([FromBody] UsuarioViewModel vmUsuario)
        {
            if (vmUsuario == null)
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));

            DAO dao = new DAO();
            dao.cadastrarUsuario(vmUsuario);
        }


    }
}
