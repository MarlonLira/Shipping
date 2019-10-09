<<<<<<< HEAD
using System;
using System.Collections.Generic;
=======
<<<<<<< .mine
<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
||||||| .r43
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
=======
﻿using Library.Commons;
using System;
>>>>>>> .r46

namespace Library.Files.CNAB150.Remessa
{
    public class RemessaCNAB150
    {
<<<<<<< .mine
=======
>>>>>>> 871a83f9cc53ee56d0bd1027fba8bdafb1f1f022
﻿using Library.Commons;
using System;

namespace Library.Files.CNAB150.Remessa
{
    public class RemessaCNAB150
    {
        public RemessaCNAB150(Empresa Empresa, Cliente Cliente, Int32 SequencialArquivo) {
            this.ClienteSacado = Cliente;
            this.EmpresaCedente = Empresa;
            this.Registros = new Registro() { SequencialArquivo = SequencialArquivo };
        }

        public RemessaCNAB150(Empresa Empresa, Int32 SequencialArquivo) {
            this.EmpresaCedente = Empresa;
            this.Registros = new Registro() { SequencialArquivo = SequencialArquivo };
        }

        public Empresa EmpresaCedente { get; set; }
        public Registro Registros { get; set; }
        public Cliente ClienteSacado { get; set; }
<<<<<<< HEAD

=======
>>>>>>> 033f699ac13220b0f95171174182be7644f7ccf3
||||||| .r43
=======
        public RemessaCNAB150(Empresa Empresa, Cliente Cliente, Int32 SequencialArquivo) {
            this.ClienteSacado = Cliente;
            this.EmpresaCedente = Empresa;
            this.Registros = new Registro() { SequencialArquivo = SequencialArquivo };
        }

        public RemessaCNAB150(Empresa Empresa, Int32 SequencialArquivo) {
            this.EmpresaCedente = Empresa;
            this.Registros = new Registro() { SequencialArquivo = SequencialArquivo };
        }

        public Empresa EmpresaCedente { get; set; }
        public Registro Registros { get; set; }
        public Cliente ClienteSacado { get; set; }
>>>>>>> .r46
>>>>>>> 871a83f9cc53ee56d0bd1027fba8bdafb1f1f022
    }
}
