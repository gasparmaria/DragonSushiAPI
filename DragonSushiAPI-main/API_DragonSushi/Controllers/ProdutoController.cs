using API_DragonSushi.Metodos;
using API_DragonSushi.Models;
using API_DragonSushi.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;

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

        [HttpPost]
        public void Post([FromBody] ProdutoViewModel vmProduto)
        {
            if (vmProduto == null)
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));

            DAO dao = new DAO();
            dao.cadastrarProduto(vmProduto);
        }
    }
}
