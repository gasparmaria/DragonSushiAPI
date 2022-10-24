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
    public class ProdutoDAO
    {
        public List<Produto> spExibirCardapio()
        {
            DataBase db = new DataBase();

            MySqlCommand exibir = new MySqlCommand("call spExibirCardapio()", db.conectarDb());
            var leitor = exibir.ExecuteReader();

            return listaTodosOsDados(leitor);

        }

        public List<Produto> listaTodosOsDados(MySqlDataReader leitor)
        {
            var cardapio = new List<Produto>();
            if (leitor.HasRows)
            {
                while (leitor.Read())
                {
                    var produto = new Produto()
                    {
                        idProd = Convert.ToInt32(leitor["idProd"]),
                        nomeProd = Convert.ToString(leitor["nomeProd"]),
                        imgProd = Convert.ToString(leitor["imgProd"]),
                        descrProd = Convert.ToString(leitor["descrProd"]),
                        preco = Convert.ToDecimal(leitor["preco"]),
                        estoque = Convert.ToBoolean(leitor["estoque"]),
                        ingrediente = Convert.ToBoolean(leitor["ingrediente"]),
                        fkCategoria = Convert.ToInt32(leitor["fkCategoria"]),
                        qntdProd = 0,
                        fkUnMedida = 0
                    };
                    cardapio.Add(produto);
                }
            }
            leitor.Close();
            return cardapio;
        }

        public void cadastrarProduto(ProdutoViewModel vmProduto)
        {
            DataBase db = new DataBase();

            string insertQuery = String.Format("call spCadastrarProduto(@nomeProd,@imgProd,@descrProd,@preco,@estoque, @ingrediente, @categoria, @qntdProd, @unMedida)");
            MySqlCommand command = new MySqlCommand(insertQuery, db.conectarDb());
            command.Parameters.Add("@nomeProd", MySqlDbType.VarChar).Value = vmProduto.Produto.nomeProd;
            command.Parameters.Add("@imgProd", MySqlDbType.VarChar).Value = vmProduto.Produto.imgProd;
            command.Parameters.Add("@descrProd", MySqlDbType.VarChar).Value = vmProduto.Produto.descrProd;
            command.Parameters.Add("@preco", MySqlDbType.Decimal).Value = vmProduto.Produto.preco;  
            command.Parameters.Add("@estoque", MySqlDbType.Byte).Value = vmProduto.Produto.estoque;
            command.Parameters.Add("@ingrediente", MySqlDbType.Byte).Value = vmProduto.Produto.ingrediente;
            command.Parameters.Add("@categoria", MySqlDbType.VarChar).Value = vmProduto.Categoria.categoria;
            command.Parameters.Add("@qntdProd", MySqlDbType.Decimal).Value = vmProduto.Produto.qntdProd;
            command.Parameters.Add("@unMedida", MySqlDbType.VarChar).Value = vmProduto.UnMedida.unMedida;

            command.ExecuteNonQuery();
            db.desconectarDb();
        }
    }
}