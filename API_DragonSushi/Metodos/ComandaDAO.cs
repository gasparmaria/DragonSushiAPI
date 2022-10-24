using API_DragonSushi.Data;
using API_DragonSushi.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_DragonSushi.Metodos
{
    public class ComandaDAO
    {
        public void cadastrarComanda(Comanda comanda)
        {
            DataBase db = new DataBase();

            string insertQuery = String.Format("spCadastrarComanda(@numMesa)");
            MySqlCommand command = new MySqlCommand(insertQuery, db.conectarDb());
            command.Parameters.Add("@numMesa", MySqlDbType.Int16).Value = comanda.numMesa;



            command.ExecuteNonQuery();
            db.desconectarDb();
        }
    }
}