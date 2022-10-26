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
        // CADASTRAR FUNCIONÁRIO
        [HttpPost]
        public void Post([FromBody] FuncionarioViewModel vmFuncionario)
        {
            if (vmFuncionario == null)
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));

            FuncionarioDAO dao = new FuncionarioDAO();
            dao.cadastrarFuncionario(vmFuncionario);
        }

        // CONSULTAR FUNCIONÁRIO PELO NOME
        [HttpGet]
        public FuncionarioViewModel Get(string nomePessoa)
        {
            FuncionarioDAO dao = new FuncionarioDAO();
            var funcionario = dao.ConsultarFuncionarioPeloNome(nomePessoa);
            return funcionario;
        }

        // EXCLUIR FUNCIONÁRIO
        [HttpDelete]
        public void ExcluirFuncionario(int id)
        {
            FuncionarioDAO dao = new FuncionarioDAO();
            dao.ExcluirFuncionario(id);
        }
    }
}
