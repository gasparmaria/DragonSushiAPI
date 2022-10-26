﻿using API_DragonSushi.Data;
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
        // CADASTRAR PRODUTO
        public void CadastrarProduto(ProdutoViewModel vmProduto)
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
            command.Parameters.Add("@qntdProd", MySqlDbType.Decimal).Value = vmProduto.Produto.qtdProd;
            command.Parameters.Add("@unMedida", MySqlDbType.VarChar).Value = vmProduto.UnMedida.unMedida;

            command.ExecuteNonQuery();
            db.desconectarDb();
        }

        // LISTAR PRODUTOS DO CARDÁPIO
        public List<ProdutoViewModel> ExibirCardapio()
        {
            DataBase db = new DataBase();

            MySqlCommand exibir = new MySqlCommand("call spExibirCardapio()", db.conectarDb());
            var leitor = exibir.ExecuteReader();

            return listaCardapio(leitor);
        }

        // LISTAR CARDÁPIO ATRAVÉS DA CATEGORIA
        public List<ProdutoViewModel> ConsultarCategoria(int fkCategoria)
        {
            DataBase db = new DataBase();
            {
                string strQuery = string.Format("CALL spExibirCategoria('{0}');", fkCategoria);
                MySqlCommand exibir = new MySqlCommand(strQuery, db.conectarDb());
                var leitor = exibir.ExecuteReader();
                return listaCardapio(leitor);
            }
        }

        // CONSULTAR CARDÁPIO PELO NOME DO PRODUTO
        public ProdutoViewModel ConsultarCardapio(string nomeProd)
        {
            DataBase db = new DataBase();
            {
                string strQuery = string.Format("CALL spConsultarCardapio('{0}');", nomeProd);
                MySqlCommand exibir = new MySqlCommand(strQuery, db.conectarDb());
                var leitor = exibir.ExecuteReader();
                return listaCardapio(leitor).FirstOrDefault();
            }
        }

        // GERADOR DE LISTA DE PRODUTOS DO CARDÁPIO
        public List<ProdutoViewModel> listaCardapio(MySqlDataReader leitor)
        {
            var produto = new List<ProdutoViewModel>();

            while (leitor.Read())
            {
                var lstProduto = new ProdutoViewModel()
                {
                    Produto = new Produto()
                    {
                        idProd = Convert.ToInt32(leitor["idProd"]),
                        nomeProd = Convert.ToString(leitor["nomeProd"]),
                        imgProd = Convert.ToString(leitor["imgProd"]),
                        descrProd = Convert.ToString(leitor["descrProd"]),
                        preco = Convert.ToDecimal(leitor["preco"]),
                        fkCategoria = Convert.ToInt32(leitor["fkCategoria"])
                    }                       
                };
                produto.Add(lstProduto);
            }
            
            leitor.Close();
            return produto;
        }

        // LISTAR PRODUTOS DO ESTOQUE
        public List<ProdutoViewModel> spExibirEstoque()
        {
            DataBase db = new DataBase();

            MySqlCommand exibir = new MySqlCommand("call spExibirEstoque()", db.conectarDb());
            var leitor = exibir.ExecuteReader();

            return listaEstoque(leitor);
        }

        // CONSULTAR ESTOQUE PELO NOME DO PRODUTO
        public ProdutoViewModel ConsultarEstoque(string nomeProd)
        {
            DataBase db = new DataBase();
            {
                string strQuery = string.Format("CALL spConsultarEstoque('{0}');", nomeProd);
                MySqlCommand exibir = new MySqlCommand(strQuery, db.conectarDb());
                var leitor = exibir.ExecuteReader();
                return listaEstoque(leitor).FirstOrDefault();
            }
        }

        // GERADOR DE LISTA DE PRODUTOS DO ESTOQUE
        public List<ProdutoViewModel> listaEstoque(MySqlDataReader leitor)
        {
            var produto = new List<ProdutoViewModel>();

            while (leitor.Read())
            {
                var lstProduto = new ProdutoViewModel()
                {
                    Produto = new Produto()
                    {
                        idProd = Convert.ToInt32(leitor["idProd"]),
                        nomeProd = Convert.ToString(leitor["nomeProd"]),
                        qtdProd = Convert.ToDecimal(leitor["qntdProd"]),
                        fkUnMedida = Convert.ToInt32(leitor["fkUnMedida"])
                    }
                };
                produto.Add(lstProduto);
            }

            leitor.Close();
            return produto;
        }
    }
}