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

        // CONSULTAR CARDÁPIO PELO NOME DO PRODUTO
        public UsuarioViewModel ConsultarUsuario(string login)
        {
            DataBase db = new DataBase();
            {
                string strQuery = string.Format("CALL spConsultarUsuario('{0}');", login);
                MySqlCommand exibir = new MySqlCommand(strQuery, db.conectarDb());
                var leitor = exibir.ExecuteReader();
                return listaUsuario(leitor).FirstOrDefault();
            }
        }

        public List<UsuarioViewModel> listaUsuario(MySqlDataReader leitor)
        {
            var usuario = new List<UsuarioViewModel>();

            while (leitor.Read())
            {
                var lstUsuario = new UsuarioViewModel()
                {
                    Usuario = new Usuario()
                    {
                        idUsuario = Convert.ToInt32(leitor["idUsuario"]),
                        login = Convert.ToString(leitor["login"]),
                        senha = Convert.ToString(leitor["senha"]),
                    },
                    Pessoa = new Pessoa()
                    {
                        idPessoa = Convert.ToInt32(leitor["idUsuario"]),
                        nomePessoa = Convert.ToString(leitor["nomePessoa"]),
                        telefone = Convert.ToString(leitor["telefone"]),
                        cpf = Convert.ToString(leitor["cpf"]),
                    }
                };
                usuario.Add(lstUsuario);
            }

            leitor.Close();
            return usuario;
        }
    }
}