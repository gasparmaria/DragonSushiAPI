using API_DragonSushi.Data;
using API_DragonSushi.ViewModel;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_DragonSushi.Metodos
{
    public class ReservaDAO
    {
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
    }
}