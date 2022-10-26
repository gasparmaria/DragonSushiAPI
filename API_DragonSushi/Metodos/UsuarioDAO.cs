using API_DragonSushi.Data;
using API_DragonSushi.ViewModel;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_DragonSushi.Metodos
{
    public class UsuarioDAO
    {
        // CADASTRAR USUÁRIO
        public void cadastrarUsuario(UsuarioViewModel vmUsuario)
        {
            DataBase db = new DataBase();

            string insertQuery = String.Format("call spCadastrarUsuario(@nomePessoa,@telefone,@cpf,@login,@senha)");
            MySqlCommand command = new MySqlCommand(insertQuery, db.conectarDb());
            command.Parameters.Add("@nomePessoa", MySqlDbType.VarChar).Value = vmUsuario.Pessoa.nomePessoa;
            command.Parameters.Add("@telefone", MySqlDbType.VarChar).Value = vmUsuario.Pessoa.telefone;
            command.Parameters.Add("@cpf", MySqlDbType.VarChar).Value = vmUsuario.Pessoa.cpf;
            command.Parameters.Add("@login", MySqlDbType.VarChar).Value = vmUsuario.Usuario.login;
            command.Parameters.Add("@senha", MySqlDbType.VarChar).Value = vmUsuario.Usuario.senha;

            command.ExecuteNonQuery();
            db.desconectarDb();
        }
    }
}