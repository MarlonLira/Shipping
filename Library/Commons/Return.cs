using Library.Banks;
using System;
using System.Collections.Generic;

namespace Library.Commons {
    public class Return {

        public List<Cliente> Cliente { get; set; }
        public Empresa Empresa { get; set; }
        public dynamic Banco { get; set; }
        public Registro Registro { get; set; }
        public String[] Ocorrencias { get; set; } = new string[5];
        public Int32 TipoInscricaoEmp { get; set; }

    }
}
