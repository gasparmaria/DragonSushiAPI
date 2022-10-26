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
    }
}