using API_DragonSushi.Models;
using API_DragonSushi.Metodos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using API_DragonSushi.ViewModel;

namespace API_DragonSushi.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: api/Usuario
        [System.Web.Http.HttpPost]
        public void CadastrarUsuario([FromBody] UsuarioViewModel vmUsuario )

        {
            if (vmUsuario == null)
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));

            var DAO = new DAO();
                DAO.CadastrarUsuario(vmUsuario);
  
        }
       
    }
}
