using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Commons
{
    public class Cliente
    {
        public String Nome { get; set; }
        public String CPF { get; set; }
        public ContaBancaria ContaBancaria { get; set; }
    }
}
