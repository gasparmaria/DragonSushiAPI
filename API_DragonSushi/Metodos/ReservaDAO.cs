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
    public class ReservaDAO
    {
        public List<ReservaViewModel> ExibirReserva(DateTime data)
        {
            DataBase db = new DataBase();
            {
                string strQuery = string.Format("CALL spExibirReservas('{0}');", data);
                MySqlCommand exibir = new MySqlCommand(strQuery, db.conectarDb());
                var leitor = exibir.ExecuteReader();
                return listaReserva(leitor);
            }
        }

        public ReservaViewModel ConsultarReserva(string cpf)
        {
            DataBase db = new DataBase();
            {
                string strQuery = string.Format("CALL spConsultarReserva('{0}');", cpf);
                MySqlCommand exibir = new MySqlCommand(strQuery, db.conectarDb());
                var leitor = exibir.ExecuteReader();
                return listaReserva(leitor).FirstOrDefault();
            }
        }

        public List<ReservaViewModel> listaReserva(MySqlDataReader leitor)
        {
            var reserva = new List<ReservaViewModel>();

            while (leitor.Read())
            {

                var lstReserva = new ReservaViewModel()
                {

                    Reserva = new Reserva()
                    {

                        idReserva = Convert.ToInt32(leitor["idReserva"]),
                        dataReserva = Convert.ToDateTime(leitor["dataReserva"]),
                        hora = TimeSpan.Parse(Convert.ToString(leitor["hora"])),
                        numPessoas = Convert.ToInt32(leitor["numPessoas"]),
                        fkPessoa = Convert.ToInt32(leitor["fkPessoa"])

                    },
                    
                };
                reserva.Add(lstReserva);
            }

            leitor.Close();
            return reserva;
        }

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