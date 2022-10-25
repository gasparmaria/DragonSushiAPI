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
        public List<Comanda> ExibirComanda()
        {
            DataBase db = new DataBase();

            MySqlCommand exibir = new MySqlCommand("call spExibirComandas()", db.conectarDb());
            var leitor = exibir.ExecuteReader();

            return listaComanda(leitor);

        }

        public Comanda ConsultarComanda(int num)
        {
            DataBase db = new DataBase();
            {
                string strQuery = string.Format("CALL spConsultarComanda('{0}');", num);
                MySqlCommand exibir = new MySqlCommand(strQuery, db.conectarDb());
                var leitor = exibir.ExecuteReader();
                return listaComanda(leitor).FirstOrDefault();
            }
        }

        public List<Comanda> listaComanda(MySqlDataReader leitor)
        {
            var comanda = new List<Comanda>();

            while (leitor.Read())
            {

                var lstComanda = new Comanda()


                {

                    idComanda = Convert.ToInt32(leitor["idComanda"]),
                    numMesa = Convert.ToInt32(leitor["numMesa"]),
                    statusComanda = Convert.ToBoolean(leitor["statusComanda"])

                };

                
                comanda.Add(lstComanda);
            }

            leitor.Close();
            return comanda;
        }

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