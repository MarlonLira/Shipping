using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Library.Bancos.Itau
{
    public class Itau : Banco
    {
        public Itau() {
            Codigo = "341";
            Digito = "7";
            Nome = "Itaú";
            LocalPagamento = "Pagável em qualquer banco até o vencimento.";
            Moeda = "9";
        }
    }
}
