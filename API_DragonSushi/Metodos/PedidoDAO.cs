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
    public class PedidoDAO
    {
        // CADASTRAR PEDIDO
        public void cadastrarPedido(PedidoViewModel vmPedido)
        {
            DataBase db = new DataBase();

            string insertQuery = String.Format("call spCadastrarPedido(@qtdProd,@descrPedido,@idProd,@idComanda)");
            MySqlCommand command = new MySqlCommand(insertQuery, db.conectarDb());
            command.Parameters.Add("@qtdProd", MySqlDbType.Int32).Value = vmPedido.Pedido.qtdProd;
            command.Parameters.Add("@descrPedido", MySqlDbType.VarChar).Value = vmPedido.Pedido.descrPedido;
            command.Parameters.Add("@idProd", MySqlDbType.Int32).Value = vmPedido.Produto.idProd;
            command.Parameters.Add("@idComanda", MySqlDbType.Int32).Value = vmPedido.Comanda.idComanda;

            command.ExecuteNonQuery();
            db.desconectarDb();
        }

        // EXCLUIR PEDIDO
        public void ExcluirPedido(int id)
        {
            DataBase db = new DataBase();

            string deleteQuery = String.Format("CALL spExcluirPedido('{0}')", id);
            MySqlCommand command = new MySqlCommand(deleteQuery, db.conectarDb());
            command.ExecuteNonQuery();

            db.desconectarDb();
        }

        public List<PedidoViewModel> ListarPedido(int comanda)
        {
            DataBase db = new DataBase();

            string strQuery = String.Format("CALL spPedidosComanda('{0}')", comanda);
            MySqlCommand exibir = new MySqlCommand(strQuery, db.conectarDb());
            var leitor = exibir.ExecuteReader();

            return listaPedido(leitor);
        }

        // GERADOR DE LISTA
        public List<PedidoViewModel> listaPedido(MySqlDataReader leitor)
        {
            var pedido = new List<PedidoViewModel>();

            while (leitor.Read())
            {
                var lstPedido = new PedidoViewModel()
                {
                    Pedido = new Pedido()
                    {
                        idPedido = Convert.ToInt32(leitor["idPedido"]),
                        qtdProd = Convert.ToInt32(leitor["qtdProd"]),
                        descrPedido = Convert.ToString(leitor["descrPedido"])
                    },
                    Comanda = new Comanda()
                    {
                        idComanda = Convert.ToInt32(leitor["fkComanda"])
                    },
                    Produto = new Produto()
                    {
                        idProd = Convert.ToInt32(leitor["fkProd"]),
                        nomeProd = Convert.ToString(leitor["nomeProd"]),
                        imgProd = Convert.ToString(leitor["imgProd"])

                    }
                };
                pedido.Add(lstPedido);
            }

            leitor.Close();
            return pedido;
        }


    }
}