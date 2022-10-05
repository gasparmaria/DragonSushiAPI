using API_DragonSushi.Data;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_DragonSushi.Models
{
    public class Produto
    {
        public int idProd { get; set; }
        public string nomeProd { get; set; }
        public string imgProd { get; set; }
        public string descrProd { get; set; }
        public decimal preco { get; set; }
        public bool estoque { get; set; }
        public bool ingrediente { get; set; }
        public int fkCategoria { get; set; }
        public decimal qntdProd { get; set; }
        public int fkUnMedida { get; set; }

        public List<Produto> spExibirCardapio()
        {
            DataBase db = new DataBase();

            MySqlCommand exibir = new MySqlCommand("call spExibirCardapio()", db.conectarDb());
            var dados = exibir.ExecuteReader();

            return readerToList(dados);

        }

        public List<Produto> readerToList(MySqlDataReader dados)
        {
            var cardapio = new List<Produto>();
            if (dados.HasRows)
            {
                while (dados.Read())
                {
                    var produto = new Produto()
                    {
                        idProd = Convert.ToInt32(dados["idProd"]),
                        nomeProd = Convert.ToString(dados["nomeProd"]),
                        imgProd = Convert.ToString(dados["imgProd"]),
                        descrProd = Convert.ToString(dados["descrProd"]),
                        preco = Convert.ToDecimal(dados["preco"]),
                        estoque = Convert.ToBoolean(dados["estoque"]),
                        ingrediente = Convert.ToBoolean(dados["ingrediente"]),
                        fkCategoria = Convert.ToInt32(dados["fkCategoria"]),
                        qntdProd = 0,
                        fkUnMedida = 0
                    };
                    cardapio.Add(produto);
                }
            }
            dados.Close();
            return cardapio;
        }
    }
}