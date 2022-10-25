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
        //MÉTODO SELECT CLIENTE PELO CPF
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
    }
}