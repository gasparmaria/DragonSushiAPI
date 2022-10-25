using API_DragonSushi.Data;
using API_DragonSushi.ViewModel;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_DragonSushi.Metodos
{
    public class DeliveryDAO
    {
        public void cadastrarDelivery(DeliveryViewModel vmDelivery)
        {
            DataBase db = new DataBase();

            string insertQuery = String.Format("call spCadastrarDelivery(@idPessoa,@idEndereco,@idComanda,@total,@formaPag,@numEndereco,@descrEndereco)");
            MySqlCommand command = new MySqlCommand(insertQuery, db.conectarDb());
            command.Parameters.Add("@idPessoa", MySqlDbType.Int32).Value = vmDelivery.Pessoa.idPessoa;
            command.Parameters.Add("@idEndereco", MySqlDbType.Int32).Value = vmDelivery.Endereco.idEndereco;
            command.Parameters.Add("@idComanda", MySqlDbType.Int32).Value = vmDelivery.Comanda.idComanda;
            command.Parameters.Add("@total", MySqlDbType.Decimal).Value = vmDelivery.Pagamento.total;
            command.Parameters.Add("@formaPag", MySqlDbType.VarChar).Value = vmDelivery.FormaPg.formaPag;
            command.Parameters.Add("@numEndereco", MySqlDbType.VarChar).Value = vmDelivery.Delivery.numEndereco;
            command.Parameters.Add("@descrEndereco", MySqlDbType.VarChar).Value = vmDelivery.Delivery.descrEndereco;

            command.ExecuteNonQuery();
            db.desconectarDb();
        }
    }
}