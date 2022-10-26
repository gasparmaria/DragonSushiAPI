using API_DragonSushi.Data;
using API_DragonSushi.ViewModel;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_DragonSushi.Metodos
{
    public class PagamentoDAO
    {
        // EFETUAR PAGAMENTO
        public void PagamentoComanda(PagamentoViewModel vmPagamento)
        {
            DataBase db = new DataBase();

            string insertQuery = String.Format("CALL spPagamentoComanda(@total,@formaPag,@idComanda)");
            MySqlCommand command = new MySqlCommand(insertQuery, db.conectarDb());
            command.Parameters.Add("@total", MySqlDbType.Decimal).Value = vmPagamento.Pagamento.total;
            command.Parameters.Add("@formaPag", MySqlDbType.VarChar).Value = vmPagamento.FormaPg.formaPag;
            command.Parameters.Add("@idComanda", MySqlDbType.Int32).Value = vmPagamento.Comanda.idComanda;

            command.ExecuteNonQuery();
            db.desconectarDb();
        }
    }
}