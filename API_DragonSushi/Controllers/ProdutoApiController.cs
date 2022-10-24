using API_DragonSushi.Metodos;
using API_DragonSushi.Models;
using API_DragonSushi.ViewModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API_DragonSushi.Controllers
{
    public class ProdutoApiController : ApiController
    {
        // GET: api/ProdutoApi
        [HttpGet]
        public IEnumerable Cardapio()
        {

            ProdutoDAO produto = new ProdutoDAO();
            var cardapio = produto.spExibirCardapio();

            return cardapio;


        }
        [HttpPost]
        public void Post([FromBody] ProdutoViewModel vmProduto)
        {
            if (vmProduto == null)
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));

            ProdutoDAO dao = new ProdutoDAO();
            dao.cadastrarProduto(vmProduto);
        }
    }
}
