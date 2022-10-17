using API_DragonSushi.Data;
using API_DragonSushi.Models;
using API_DragonSushi.ViewModel;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;

namespace API_DragonSushi.Metodos
{
    public class DAO
    {
        private DataBase db;

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
        //-----------------------------------------------------------------------------------------------------------------------------
        //MPETODO DE INSERÇÃO: FUNCIONÁRIO
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
        //-----------------------------------------------------------------------------------------------------------------------------
        //MÉTODO DE INSERÇÃO: CLIENTE
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
        //-----------------------------------------------------------------------------------------------------------------------------
        // MÉTODO DE INERTÇÃO: COMANDA
        public void cadastrarComanda(Comanda comanda)
        {
            DataBase db = new DataBase();

            string insertQuery = String.Format("spCadastrarComanda(@numMesa)");
            MySqlCommand command = new MySqlCommand(insertQuery, db.conectarDb());
            command.Parameters.Add("@numMesa", MySqlDbType.Int16).Value = comanda.numMesa;

            command.ExecuteNonQuery();
            db.desconectarDb();
        }
        //-----------------------------------------------------------------------------------------------------------------------------
        //MÉTODO DE INSERÇÃO:PRODUTO
        public void cadastrarProduto(ProdutoViewModel vmProduto)
        {
            DataBase db = new DataBase();

            string insertQuery = String.Format("call spCadastrarProduto(@nomeProd,@imgProd,@descrProd,@preco,@estoque, @ingrediente, @categoria, @qntdProd, @unMedida)");
            MySqlCommand command = new MySqlCommand(insertQuery, db.conectarDb());
            command.Parameters.Add("@nomeProd", MySqlDbType.VarChar).Value = vmProduto.Produto.nomeProd;
            command.Parameters.Add("@imgProd", MySqlDbType.VarChar).Value = vmProduto.Produto.imgProd;
            command.Parameters.Add("@descrProd", MySqlDbType.VarChar).Value = vmProduto.Produto.descrProd;
            command.Parameters.Add("@preco", MySqlDbType.Decimal).Value = vmProduto.Produto.preco;
            command.Parameters.Add("@estoque", MySqlDbType.Byte).Value = vmProduto.Produto.estoque;
            command.Parameters.Add("@ingrediente", MySqlDbType.Byte).Value = vmProduto.Produto.ingrediente;
            command.Parameters.Add("@categoria", MySqlDbType.VarChar).Value = vmProduto.Categoria.categoria;
            command.Parameters.Add("@qntdProd", MySqlDbType.Decimal).Value = vmProduto.Produto.qntdProd;
            command.Parameters.Add("@unMedida", MySqlDbType.VarChar).Value = vmProduto.UnMedida.unMedida;

            command.ExecuteNonQuery();
            db.desconectarDb();
        }


        //-----------------------------------------------------------------------------------------------------------------------------
        //MÉTODO DE INSERÇÃO: FUNCIONÁRIO
        public void CadastrarFuncionario(Usuario usuario, Pessoa pessoa)
        {            
            var strQuery = "";
            strQuery += string.Format("CALL spCadastrarFuncionario ('{0}','{1}','{2}','{3}','{4}')", 
                                                                pessoa.nomePessoa, 
                                                                pessoa.telefone, 
                                                                pessoa.cpf, 
                                                                usuario.login, 
                                                                usuario.senha);

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
            strQuery += string.Format("CALL spCadastrarCliente ('{0}','{1}','{2}')", pessoa.nomePessoa, pessoa.telefone, pessoa.cpf);

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
            strQuery += string.Format("CALL spCadastrarComanda ({0})", comanda.numMesa);

            using (db = new DataBase())
            {
                db.ExecutaComando(strQuery);
            }
         }

        //------------------------------------------------------------------------------------------------------------------------------
        //MÉTODO INSERÇÃO: ENDEREÇO
        public void CadastrarEndereco(Endereco endereco, Bairro bairro, Cidade cidade, Estado estado, Rua rua)
        {
            var strQuery = "";
            strQuery += string.Format("CALL spCadastrarEndereco ({0}, '{1}', '{2}', '{3}', '{4}', '{5}')", 
                                                            endereco.numEndereco, 
                                                            endereco.descrEndereco, 
                                                            rua.rua, 
                                                            bairro.bairro, 
                                                            cidade.cidade, 
                                                            estado.idEstado);

            using (db = new DataBase())
            {
                db.ExecutaComando(strQuery);
            }
        }
    }
}