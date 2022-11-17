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
        // CADASTRAR USUÁRIO
        [HttpPost]
        public void Post([FromBody] UsuarioViewModel vmUsuario)
        {
           

            UsuarioDAO dao = new UsuarioDAO();
            dao.cadastrarUsuario(vmUsuario);
        }

        // CONSULTAR USUARIO PELO LOGIN
        [HttpGet]
        public UsuarioViewModel ConsultarUsuario(string login)
        {
            UsuarioDAO dao = new UsuarioDAO();
            var usuario = dao.ConsultarUsuario(login);
            return usuario;
        }

        // EDITAR USUÁRIO
        [System.Web.Http.HttpPut]
        public void EditarUsuario([FromBody] UsuarioViewModel vmUsuario)
        {
            if (vmUsuario == null)
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));

            UsuarioDAO dao = new UsuarioDAO();
            dao.editarUsuario(vmUsuario);
        }
    }
}
