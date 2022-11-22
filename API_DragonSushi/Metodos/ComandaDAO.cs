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
        // CADASTRAR COMANDA
        public void cadastrarComanda(Comanda comanda)
        {
            DataBase db = new DataBase();

            string insertQuery = String.Format("spCadastrarComanda(@numMesa)");
            MySqlCommand command = new MySqlCommand(insertQuery, db.conectarDb());
            command.Parameters.Add("@numMesa", MySqlDbType.Int16).Value = comanda.numMesa;

            command.ExecuteNonQuery();
            db.desconectarDb();
        }

        // LISTAR COMANDAS
        public List<Comanda> ExibirComanda()
        {
            DataBase db = new DataBase();

            MySqlCommand exibir = new MySqlCommand("call spExibirComandas()", db.conectarDb());
            var leitor = exibir.ExecuteReader();

            return listaComanda(leitor);
        }

        // CONSULTAR COMANDA PELO NÚMERO
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
        // GERADOR DE LISTA
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

        // GERADOR DE LISTA NULA
        public List<Comanda> listaComandaNula()
        {
            var comanda = new List<Comanda>();

            var lstComanda = new Comanda()
            {
                idComanda = 0,
                numMesa = 0,
                statusComanda = true
            };
            comanda.Add(lstComanda);

            return comanda;
        }

        // CONSULTAR COMANDA DO DELIVERY
        public Comanda ComandaDelivery()
        {
            DataBase db = new DataBase();
            {
                MySqlCommand exibir = new MySqlCommand("CALL spComandaDelivery(0)", db.conectarDb());
                var leitor = exibir.ExecuteReader();
                var item = listaComanda(leitor).FirstOrDefault();
                if (item != null)
                    return item;
                else
                    return listaComandaNula().FirstOrDefault();
            }
        }

        public void LimparCarrinho(int comanda)
        {
            DataBase db = new DataBase();

            string deleteQuery = String.Format("CALL spLimpaComanda('{0}')", comanda);
            MySqlCommand command = new MySqlCommand(deleteQuery, db.conectarDb());
            command.ExecuteNonQuery();

            db.desconectarDb();
        }
    }
}