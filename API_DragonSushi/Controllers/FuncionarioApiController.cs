using API_DragonSushi.Metodos;
using API_DragonSushi.Models;
using API_DragonSushi.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API_DragonSushi.Controllers
{
    public class FuncionarioApiController : ApiController
    {
        [HttpGet]
        public Pessoa Get(string nomePessoa)
        {
            DAO dao = new DAO();
            var funcionario = dao.ConsultarFuncionarioPeloNome(nomePessoa);
            return funcionario;
        }

        [HttpPost]
        public void Post([FromBody] FuncionarioViewModel vmFuncionario)
        {
            if (vmFuncionario == null)
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));

            DAO dao = new DAO();
            dao.cadastrarFuncionario(vmFuncionario);
        }
    }
}
