using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dispatch.Commons.Banks
{
    public class Bancos
    {
        public Bank Banco { get; set; }
    }

    public enum Bank
    {
        Itau = 341,
        Caixa = 104
    }
}
