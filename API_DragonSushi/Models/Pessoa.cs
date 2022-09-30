using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_DragonSushi.Models
{
    public class Pessoa
    {
        public int idPessoa { get; set; }
        public string nomePessoa { get; set; }
        public string telefone { get; set; }
        public string cpf { get; set; }
        public int ocupacao { get; set; }
    }
}