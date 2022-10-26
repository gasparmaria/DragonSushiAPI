using API_DragonSushi.Data;
using API_DragonSushi.Models;
using API_DragonSushi.ViewModel;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_DragonSushi.Metodos
{
    public class FuncionarioDAO
    {
        // CADASTRAR FUNCIONÁRIO
        public void cadastrarFuncionario(FuncionarioViewModel vmFuncionario)
        {
            DataBase db = new DataBase();

            string insertQuery = String.Format("call spCadastrarFuncionario(@nomePessoa,@telefone,@cpf,@login,@senha)");
            MySqlCommand command = new MySqlCommand(insertQuery, db.conectarDb());
            command.Parameters.Add("@nomePessoa", MySqlDbType.VarChar).Value = vmFuncionario.Pessoa.nomePessoa;
            command.Parameters.Add("@telefone", MySqlDbType.VarChar).Value = vmFuncionario.Pessoa.telefone;
            command.Parameters.Add("@cpf", MySqlDbType.VarChar).Value = vmFuncionario.Pessoa.cpf;
            command.Parameters.Add("@login", MySqlDbType.VarChar).Value = vmFuncionario.Usuario.login;
            command.Parameters.Add("@senha", MySqlDbType.VarChar).Value = vmFuncionario.Usuario.senha;

            command.ExecuteNonQuery();
            db.desconectarDb();
        }

        // EXCLUIR FUNCIONÁRIO
        public void ExcluirFuncionario(int id)
        {
            DataBase db = new DataBase();

            string deleteQuery = String.Format("CALL spExcluirFuncionario('{0}')", id);
            MySqlCommand command = new MySqlCommand(deleteQuery, db.conectarDb());
            command.ExecuteNonQuery();

            db.desconectarDb();
        }

        // CONSULTAR FUNCIONÁRIO PELO NOME
        public FuncionarioViewModel ConsultarFuncionarioPeloNome(string nomePessoa)
        {
            DataBase db = new DataBase();
            {
                string strQuery = string.Format("CALL spConsultarFuncionario('{0}');", nomePessoa);
                MySqlCommand exibir = new MySqlCommand(strQuery, db.conectarDb());
                var leitor = exibir.ExecuteReader();
                return GerarListaFuncionario(leitor).FirstOrDefault();
            }
        }

        // GERADOR DE LISTA
        public List<FuncionarioViewModel> GerarListaFuncionario(MySqlDataReader leitor)
        {
            var funcionario = new List<FuncionarioViewModel>();

            while (leitor.Read())
            {
                var lstFuncionario = new FuncionarioViewModel()
                {                 
                    Pessoa = new Pessoa()
                    {
                        nomePessoa = leitor["nomePessoa"].ToString(),
                        telefone = leitor["telefone"].ToString(),
                        cpf = leitor["cpf"].ToString()
                    }
                };
                funcionario.Add(lstFuncionario);
            }
            leitor.Close();
            return funcionario;
        }
    }
}