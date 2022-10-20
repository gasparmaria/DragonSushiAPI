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

        //MÉTODO DE CONSULTA FUNCIONARIO PELO NOME DO FUNCIONÁRIO
        public Pessoa ConsultarFuncionarioPeloNome(string nomePessoa)
        {
            DataBase db = new DataBase();
            {
                string strQuery = string.Format("spConsultarFuncionario(nomePessoa);", nomePessoa);
                var leitor = db.RetornaComando(strQuery);

                return GerarListaFuncionario(leitor).FirstOrDefault();
            }
        }
        public List<Pessoa> GerarListaFuncionario(MySqlDataReader leitor)
        {
            var funcionario = new List<Pessoa>();

            while (leitor.Read())
            {
                var lstFuncionario = new Pessoa()
                {
                    idPessoa = int.Parse(leitor["idPessoa"].ToString()),
                    nomePessoa = leitor["nomePessoa"].ToString(),
                    telefone = leitor["telefone"].ToString(),
                    cpf = leitor["cpf"].ToString(),
                    ocupacao = int.Parse(leitor["ocupacao"].ToString()),

                };
                funcionario.Add(lstFuncionario);
            }
            leitor.Close();
            return funcionario;
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
        //MÉTODO DE INSERÇÃO: Endereco
        public void cadastrarEndereco(EnderecoViewModel vmEndereco)
        {
            DataBase db = new DataBase();

            string insertQuery = String.Format("call spCadastrarEndereco(@numEndereco,@descrEndereco,@rua,@bairro,@cidade, @idEstado)");
            MySqlCommand command = new MySqlCommand(insertQuery, db.conectarDb());
            command.Parameters.Add("@numEndereco", MySqlDbType.VarChar).Value = vmEndereco.Endereco.numEndereco;
            command.Parameters.Add("@descrEndereco", MySqlDbType.VarChar).Value = vmEndereco.Endereco.descrEndereco;
            command.Parameters.Add("@rua", MySqlDbType.VarChar).Value = vmEndereco.Rua.rua;
            command.Parameters.Add("@bairro", MySqlDbType.VarChar).Value = vmEndereco.Bairro.bairro;
            command.Parameters.Add("@cidade", MySqlDbType.VarChar).Value = vmEndereco.Cidade.cidade;
            command.Parameters.Add("@idEstado", MySqlDbType.VarChar).Value = vmEndereco.Estado.idEstado;


            command.ExecuteNonQuery();
            db.desconectarDb();
        }

        //-----------------------------------------------------------------------------------------------------------------------------
        //MÉTODO DE INSERÇÃO: Delivery

        public void cadastrarDelivery(DeliveryViewModel vmDelivery)
        {
            DataBase db = new DataBase();

            string insertQuery = String.Format("call spCadastrarDelivery(@idPessoa,@idEndereco,@idComanda,@total,@formaPag)");
            MySqlCommand command = new MySqlCommand(insertQuery, db.conectarDb());
            command.Parameters.Add("@idPessoa", MySqlDbType.Int32).Value = vmDelivery.Pessoa.idPessoa;
            command.Parameters.Add("@idEndereco", MySqlDbType.Int32).Value = vmDelivery.Endereco.idEndereco;
            command.Parameters.Add("@idComanda", MySqlDbType.Int32).Value = vmDelivery.Comanda.idComanda;
            command.Parameters.Add("@total", MySqlDbType.Decimal).Value = vmDelivery.Pagamento.total;
            command.Parameters.Add("@formaPag", MySqlDbType.VarChar).Value = vmDelivery.FormaPg.formaPag;

            command.ExecuteNonQuery();
            db.desconectarDb();
        }

        //-----------------------------------------------------------------------------------------------------------------------------
        //MÉTODO DE INSERÇÃO: RESERVA

        public void cadastrarReserva(ReservaViewModel vmReserva)
        {
            DataBase db = new DataBase();

            string insertQuery = String.Format("call spCadastrarReserva(@dataReserva,@hora,@numPessoas,@cpf)");
            MySqlCommand command = new MySqlCommand(insertQuery, db.conectarDb());
            command.Parameters.Add("@dataReserva", MySqlDbType.Date).Value = vmReserva.Reserva.dataReserva;
            command.Parameters.Add("@hora", MySqlDbType.Time).Value = vmReserva.Reserva.hora;
            command.Parameters.Add("@numPessoas", MySqlDbType.Int32).Value = vmReserva.Reserva.numPessoas;
            command.Parameters.Add("@cpf", MySqlDbType.VarChar).Value = vmReserva.Pessoa.cpf;


            command.ExecuteNonQuery();
            db.desconectarDb();
        }

        //-----------------------------------------------------------------------------------------------------------------------------
        //MÉTODO DE INSERÇÃO: PEDIDO
        //public void cadastrarPedido(Pedido pedido)
        //{
        //    DataBase db = new DataBase();

        //    string insertQuery = String.Format("call spCadastrarPedido(@qtdProd,@descrPedido,@fkProd,@fkComanda)");
        //    MySqlCommand command = new MySqlCommand(insertQuery, db.conectarDb());
        //    command.Parameters.Add("@qtdProd", MySqlDbType.Int32).Value = pedido.qtdProd;
        //    command.Parameters.Add("@descrPedido", MySqlDbType.VarChar).Value = pedido.descrPedido;
        //    command.Parameters.Add("@fkProd", MySqlDbType.Int32).Value = pedido.fkProd;
        //    command.Parameters.Add("@fkComanda", MySqlDbType.Int32).Value = pedido.fkComanda;


        //    command.ExecuteNonQuery();
        //    db.desconectarDb();
        //}
    }
}