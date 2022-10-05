using API_DragonSushi.Models;
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

            Produto produto = new Produto();
            var cardapio = produto.spExibirCardapio();

            return cardapio;


        }
    }
}
