using System;

namespace Library.Banks {
    public abstract class Banco {
        public String Codigo { get; set; }
        public String Digito { get; set; }
        public String Nome { get; set; }
        public String LocalPagamento { get; protected set; }
        public String Moeda { get; protected set; }
    }

    public class Debito
    {

    }
}
