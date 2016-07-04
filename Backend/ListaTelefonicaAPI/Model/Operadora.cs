using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ListaTelefonicaAPI.Model
{
    public class Operadora
    {
        public int codigo { get; set; }
        public string nome { get; set; }
        public string categoria { get; set; }
        public double preco { get; set; }
    }
}