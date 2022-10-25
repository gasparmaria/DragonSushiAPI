using API_DragonSushi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_DragonSushi.ViewModel
{
    public class EnderecoViewModel
    {
        public Endereco Endereco { get; set; }

        public Bairro Bairro { get; set; }

        public Cidade Cidade { get; set; }

        public Estado Estado { get; set; }
    }
}