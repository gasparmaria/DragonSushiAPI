using API_DragonSushi.Data;
using API_DragonSushi.Metodos;
using API_DragonSushi.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_DragonSushi.ViewModel
{
    public class UsuarioViewModel
    {
        public Usuario Usuario { get; set; }
        public Pessoa Pessoa { get; set; }

        public List<UsuarioViewModel> listarUsuarios()
        {
            DataBase db = new DataBase();

            MySqlCommand exibir = new MySqlCommand("spExibirUsuario()", db.conectarDb());
            var dados = exibir.ExecuteReader();

            return readerToList(dados);
        }

        public List<UsuarioViewModel> readerToList(MySqlDataReader dados)
        {
            var lista = new List<UsuarioViewModel>();
            if (dados.HasRows)
            {
                while (dados.Read())
                {
                    var vmUsuario = new UsuarioViewModel()
                    {
                        Pessoa = new Pessoa()
                        {
                            nomePessoa = Convert.ToString(dados["nomePessoa"]),
                            telefone = Convert.ToString(dados["telefone"]),
                            cpf = Convert.ToString(dados["cpf"])
                        },

                        Usuario = new Usuario()
                        {
                            login = Convert.ToString(dados["login"]),
                            senha = Convert.ToString(dados["senha"])
                        }
                    };
                    lista.Add(vmUsuario);
                }
            }
            dados.Close();
            return lista;
        }

       
    }
}