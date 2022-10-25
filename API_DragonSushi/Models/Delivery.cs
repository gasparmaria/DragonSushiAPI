using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_DragonSushi.Models
{
    public class Delivery
    {
        public int idDelivery { get; set; }
        public DateTime dataDelivery { get; set; }
        public string numEndereco { get; set; }
        public string descrEndereco { get; set; }
        public int fkPessoa { get; set; }
        public int fkEndereco { get; set; }
        public int fkComanda { get; set; }
        public int fkPag { get; set; }
    }
}