using API_DragonSushi.Data;
using API_DragonSushi.Metodos;
using API_DragonSushi.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_DragonSushi.ViewModel
{
    public class UsuarioViewModel
    {
        public Usuario Usuario { get; set; }

        public Pessoa Pessoa { get; set; } 
    }
}