using API_DragonSushi.Data;
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