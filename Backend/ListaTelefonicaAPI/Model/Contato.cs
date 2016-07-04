using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ListaTelefonicaAPI.Model
{
    public class Contato
    {
        public int id { get; set; }
        public string nome { get; set; }
        public DateTime data { get; set; }
        public string telefone{ get; set; }
        public Operadora operadora { get; set; }
    }
}