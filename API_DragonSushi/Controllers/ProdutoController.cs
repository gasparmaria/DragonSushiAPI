using API_DragonSushi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace API_DragonSushi.Controllers
{
    public class ProdutoController : Controller
    {
        public ActionResult Cardapio()
        {
            Produto produto = new Produto();
            var cardapio = produto.spExibirCardapio();
            return View(cardapio);
        }
    }
}
