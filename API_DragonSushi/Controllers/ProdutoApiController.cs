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
        // CADASTRAR PRODUTO
        [HttpPost]
        public void Post([FromBody] ProdutoViewModel vmProduto)
        {
            if (vmProduto == null)
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));

            ProdutoDAO dao = new ProdutoDAO();
            dao.CadastrarProduto(vmProduto);
        }

        // LISTAR PRODUTOS DO CARDÁPIO
        [HttpGet]
        public IEnumerable Cardapio()
        {
            ProdutoDAO dao = new ProdutoDAO();
            var cardapio = dao.ExibirCardapio();

            return cardapio;
        }

        // LISTAR CARDÁPIO ATRAVÉS DA CATEGORIA
        [HttpGet]
        public IEnumerable ConsultarCategoria(int fkCategoria)
        {
            ProdutoDAO dao = new ProdutoDAO();
            var produto = dao.ConsultarCategoria(fkCategoria);
            return produto;
        }

        // CONSULTAR CARDÁPIO PELO NOME DO PRODUTO
        [HttpGet]
        public ProdutoViewModel ConsultarCardapio(string nomeProd)
        {
            ProdutoDAO dao = new ProdutoDAO();
            var produto = dao.ConsultarCardapio(nomeProd);
            return produto;
        }

        // LISTAR PRODUTOS DO ESTOQUE
        [HttpGet]
        public IEnumerable Estoque()
        {
            ProdutoDAO dao = new ProdutoDAO();
            var estoque = dao.spExibirEstoque();

            return estoque;
        }

        // CONSULTAR ESTOQUE PELO NOME DO PRODUTO
        [HttpGet]
        public ProdutoViewModel ConsultarEstoque(string nomeProd)
        {
            ProdutoDAO dao = new ProdutoDAO();
            var produto = dao.ConsultarEstoque(nomeProd);
            return produto;
        }
    }
}
