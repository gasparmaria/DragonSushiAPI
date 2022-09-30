using API_DragonSushi.Data;
using API_DragonSushi.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_DragonSushi.Metodos
{
    public class DAO
    {
        private DataBase db;

       //-----------------------------------------------------------------------------------------------------------------------------
        //MÉTODO DE INSERÇÃO: USUÁRIO  
        public void CadastrarUsuario(Usuario usuario, Pessoa pessoa)
        {
            var strQuery = "";
            strQuery += string.Format("Call spCadastrarUsuario ('{0}','{1}','{2}','{3}','{4}')", pessoa.nomePessoa, pessoa.telefone, pessoa.cpf, usuario.login, usuario.senha);


            using (db = new DataBase())
            {
                db.ExecutaComando(strQuery);
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------
        //MÉTODO DE INSERÇÃO: FUNCIONÁRIO
        public void CadastrarFuncionario(Usuario usuario, Pessoa pessoa)
        {
            var strQuery = "";
            strQuery += string.Format("spCadastrarFuncionario ('{0}','{1}','{2}','{3}','{4}')", pessoa.nomePessoa, pessoa.telefone, pessoa.cpf, usuario.login, usuario.senha);


            using (db = new DataBase())
            {
                db.ExecutaComando(strQuery);
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------
        //MÉTODO DE INSERÇÃO: CLIENTE
        public void CadastrarCliente(Pessoa pessoa)
        {
            var strQuery = "";
            strQuery += string.Format("spCadastrarCliente ('{0}','{1}','{2}')", pessoa.nomePessoa, pessoa.telefone, pessoa.cpf);


            using (db = new DataBase())
            {
                db.ExecutaComando(strQuery);
            }
        }

        //------------------------------------------------------------------------------------------------------------------------------
        //MÉTODO INSERÇÃO: COMANDA
         public void CadastrarComanda(Comanda comanda)
        {
            var strQuery = "";
            strQuery += string.Format("spCadastrarComanda ({0})", comanda.numMesa);


            using (db = new DataBase())
            {
                db.ExecutaComando(strQuery);
            }
        }
    }
}