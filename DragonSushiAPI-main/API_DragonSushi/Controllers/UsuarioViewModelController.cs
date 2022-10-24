using API_DragonSushi.Metodos;
using API_DragonSushi.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace API_DragonSushi.Controllers
{
    public class UsuarioViewModelController : Controller
    {
        public ActionResult ListarUsuarios()
        {
            UsuarioViewModel vmUsuario = new UsuarioViewModel();
            var listaUsuarios = vmUsuario.listarUsuarios();

            return View(listaUsuarios);
        }

        public ActionResult CadastrarUsuario()
        {
            return View();
        }
    }
}