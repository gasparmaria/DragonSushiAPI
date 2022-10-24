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

    }
}