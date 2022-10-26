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
    public class ClienteDAO
    {
        // CADASTRAR CLIENTE
        public void cadastrarCliente(ClienteViewModel vmCliente)
        {
            DataBase db = new DataBase();

            string insertQuery = String.Format("spCadastrarCliente(@nomePessoa,@telefone,@cpf)");
            MySqlCommand command = new MySqlCommand(insertQuery, db.conectarDb());
            command.Parameters.Add("@nomePessoa", MySqlDbType.VarChar).Value = vmCliente.Pessoa.nomePessoa;
            command.Parameters.Add("@telefone", MySqlDbType.VarChar).Value = vmCliente.Pessoa.telefone;
            command.Parameters.Add("@cpf", MySqlDbType.VarChar).Value = vmCliente.Pessoa.cpf;

            command.ExecuteNonQuery();
            db.desconectarDb();
        }

        // EDITAR CLIENTE
        public void EditarCliente(ClienteViewModel vmCliente)
        {
<<<<<<< HEAD
            DataBase db = new DataBase();
            string updateQuery = String.Format("CALL spEditarCliente(@idPessoa,@nomePessoa,@telefone,@cpf)");

            MySqlCommand command = new MySqlCommand(updateQuery, db.conectarDb());
            command.Parameters.Add("@idPessoa", MySqlDbType.Int32).Value = vmCliente.Pessoa.idPessoa;
            command.Parameters.Add("@nomePessoa", MySqlDbType.VarChar).Value = vmCliente.Pessoa.nomePessoa;
            command.Parameters.Add("@telefone", MySqlDbType.VarChar).Value = vmCliente.Pessoa.telefone;
            command.Parameters.Add("@cpf", MySqlDbType.VarChar).Value = vmCliente.Pessoa.cpf;

            try
            {
                command.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                db.desconectarDb();

            }
        }
=======
            string strQuery = string.Format("CALL spEditarCliente('{0}','{1}','{2}','{3}');", vmCliente.Pessoa.idPessoa,vmCliente.Pessoa.nomePessoa,vmCliente.Pessoa.telefone,vmCliente.Pessoa.cpf );

            using (DataBase db = new DataBase())
            {
                db.ExecutaComando(strQuery);
            }
        }

>>>>>>> 2a3dc8ec035c09d63b1a36c887010c0ddf302f15
        // CONSULTAR CLIENTE PELO CPF
        public ClienteViewModel ConsultarCliente(string cpf)
        {
            DataBase db = new DataBase();
            {
                string strQuery = string.Format("CALL spConsultarCliente('{0}');", cpf);
                MySqlCommand exibir = new MySqlCommand(strQuery, db.conectarDb());
                var leitor = exibir.ExecuteReader();
                return GerarListaCliente(leitor).FirstOrDefault();
            }
        }

        // GERADOR DE LISTA
        public List<ClienteViewModel> GerarListaCliente(MySqlDataReader leitor)
        {
            var cliente = new List<ClienteViewModel>();

            while (leitor.Read())
            {
                var lstCliente = new ClienteViewModel()
                {
                    Pessoa = new Pessoa()
                    {
                        nomePessoa = leitor["nomePessoa"].ToString(),
                        telefone = leitor["telefone"].ToString(),
                        cpf = leitor["cpf"].ToString(),
                    }
                };
                cliente.Add(lstCliente);
            }
            leitor.Close();
            return cliente;
        }
<<<<<<< HEAD
    }   
=======
    }
>>>>>>> 2a3dc8ec035c09d63b1a36c887010c0ddf302f15
}