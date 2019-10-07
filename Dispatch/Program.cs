using Dispatch.Commons.Banks;
using Dispatch.Commons.Files;
using Library.Banks;
using Library.Commons;
using Library.Files.CNAB240.Retorno;
using System;
using System.Collections.Generic;
using System.Text;
using static Library.Commons.Empresa;

namespace Dispatch {
    class Program {
        static void Main(string[] args) {

            Itau Banco = new Itau();

            var Empresa = new Empresa()
            {
                CNPJ = "31892890000117",
                Nome = "CENTRO DE ATIV E C F S LTDA",
                Convenio = "4998108312126",
                Juros = 0.2f,
                IdentificadorExtrato = "HIX024",
                Mora = MoraTipo.Isento,
                ContaBancaria = new ContaBancaria()
                {
                    Conta = "32803",
                    Digito = "2",
                    AgenciaBancaria = new AgenciaBancaria()
                    {
                        Agencia = "9248",
                        Digito = "2"
                    }
                },
                Endereco = new Endereco()
                {
                    Nome = "Rua Zeferino Agra, Arruda",
                    CEP = "52120180",
                    Cidade = "Recife",
                    Numero = 519,
                    EstadoSigla = "PE",
                    Tipo = "Academia"
                }
            };

            var Cliente = new Cliente() {
                CPF = "09665664580",
                Nome = "Arthur Polegadas",
                CobrancaAgendada = new List<Cobranca>() {
                    new Cobranca { Descricao = "Parcela" , Valor = 1014f, Data = Convert.ToDateTime("25/01/2020") }
                },
                ContaBancaria = new ContaBancaria() {
                    Conta = "28170",
                    Digito = "7",
                    AgenciaBancaria = new AgenciaBancaria() {
                        Agencia = "6942",
                        Digito = "2"
                    },
                },
            };

            var Cliente2 = new Cliente() {
                CPF = "09177350480",
                Nome = "Marlon Lira",
                CobrancaAgendada = new List<Cobranca>() {
                    new Cobranca { Descricao = "Parcela" , Valor = 59.9f, Data = Convert.ToDateTime("25/01/2020"), PctIOF = 0.04f},
                    new Cobranca { Descricao = "Parcela" , Valor = 59.9f, Data = Convert.ToDateTime("25/02/2020"), PctIOF = 0.04f},
                    new Cobranca { Descricao = "Parcela" , Valor = 59.9f, Data = Convert.ToDateTime("25/03/2020"), PctIOF = 0.04f},
                    new Cobranca { Descricao = "Parcela" , Valor = 59.9f, Data = Convert.ToDateTime("25/04/2020"), PctIOF = 0.04f},
                    new Cobranca { Descricao = "Parcela" , Valor = 59.9f, Data = Convert.ToDateTime("25/05/2020"), PctIOF = 0.04f},
                    new Cobranca { Descricao = "Parcela" , Valor = 59.9f, Data = Convert.ToDateTime("25/06/2020"), PctIOF = 0.04f},
                    new Cobranca { Descricao = "Parcela" , Valor = 59.9f, Data = Convert.ToDateTime("25/07/2020"), PctIOF = 0.04f},
                    new Cobranca { Descricao = "Parcela" , Valor = 59.9f, Data = Convert.ToDateTime("25/08/2020"), PctIOF = 0.04f},
                    new Cobranca { Descricao = "Parcela" , Valor = 59.9f, Data = Convert.ToDateTime("25/09/2020"), PctIOF = 0.04f},
                    new Cobranca { Descricao = "Parcela" , Valor = 59.9f, Data = Convert.ToDateTime("25/10/2020"), PctIOF = 0.04f},
                    new Cobranca { Descricao = "Parcela" , Valor = 59.9f, Data = Convert.ToDateTime("25/11/2020"), PctIOF = 0.04f},
                    new Cobranca { Descricao = "Parcela" , Valor = 59.9f, Data = Convert.ToDateTime("25/12/2020"), PctIOF = 0.04f}
                },
                ContaBancaria = new ContaBancaria() {
                    Conta = "58765",
                    Digito = "9",
                    AgenciaBancaria = new AgenciaBancaria() {
                        Agencia = "6985",
                        Digito = "3"
                    },
                },
            };

            /* List<Cliente> Clientes = new List<Cliente>() {
                 new Cliente() {
                     CPF = "09266777450",
                     Nome = "Maria Benta",
                     CobrancaAgendada = new List<Cobranca>() {
                         new Cobranca { Descricao = "Taxa" , Valor = 19.99f, Data = Convert.ToDateTime("25/09/2019"), PctIOF = 0.1f },
                         new Cobranca { Descricao = "Parcela" , Valor = 114f, Data = Convert.ToDateTime("25/10/2019"), PctIOF = 0.1f }
                     },
                     Endereco = new Endereco() {
                         CEP = "541253680",
                         Cidade = "Recife",
                         Nome = "Dinopolis Arruda",
                         EstadoSigla = "PE",
                         Numero = 1025,
                         Tipo = "Rua"
                     },
                     ContaBancaria = new ContaBancaria() {
                         Conta = "78586",
                         Digito = "7",
                         AgenciaBancaria = new AgenciaBancaria() {
                             Agencia = "9633",
                             Digito = "3"
                         }
                     }
                 },
                 new Cliente() {
                     CPF = "09266544450",
                     Nome = "Bernadino Pessoa",
                     CobrancaAgendada = new List<Cobranca>() {
                         new Cobranca { Descricao = "Taxa" , Valor = 29.99f, Data = Convert.ToDateTime("25/07/2019")},
                         new Cobranca { Descricao = "Parcela" , Valor = 99f, Data = Convert.ToDateTime("25/08/2020") }
                     },
                     Endereco = new Endereco() {
                         CEP = "548553680",
                         Cidade = "Recife",
                         Nome = "Aleixinho",
                         EstadoSigla = "PE",
                         Numero = 105,
                         Tipo = "Rua"
                     },
                     ContaBancaria = new ContaBancaria() {
                         Conta = "98582",
                         Digito = "7",
                         AgenciaBancaria = new AgenciaBancaria() {
                             Agencia = "9699",
                             Digito = "3"
                         }
                     }
                 },
                 new Cliente() {
                     CPF = "09266511450",
                     Nome = "Zumira Bernardo",
                     CobrancaAgendada = new List<Cobranca>() {
                     new Cobranca { Descricao = "Taxa" , Valor = 19.90f, Data = Convert.ToDateTime("07/05/2020")},
                     new Cobranca { Descricao = "Parcela" , Valor = 69f, Data = Convert.ToDateTime("07/04/2020")}
                     },
                     Endereco = new Endereco() {
                         CEP = "547253880",
                         Cidade = "Recife",
                         Nome = "Arrudandalia",
                         EstadoSigla = "PE",
                         Numero = 102,
                         Tipo = "Rua"
                     },
                     ContaBancaria = new ContaBancaria() {
                         Conta = "78886",
                         Digito = "7",
                         AgenciaBancaria = new AgenciaBancaria() {
                             Agencia = "8733",
                             Digito = "3"
                         }
                     }
                 },
                 new Cliente() {
                     CPF = "09266511450",
                     Nome = "Carlos Eduardo",
                     CobrancaAgendada = new List<Cobranca>() {
                     new Cobranca { Descricao = "Taxa" , Valor = 19.90f, Data = Convert.ToDateTime("12/12/2020")},
                     new Cobranca { Descricao = "Parcela" , Valor = 79f, Data = Convert.ToDateTime("01/11/2019")}
                     },
                     Endereco = new Endereco() {
                         CEP = "547253880",
                         Cidade = "Recife",
                         Nome = "Varzea",
                         EstadoSigla = "PE",
                         Numero = 850,
                         Tipo = "Rua"
                     },
                     ContaBancaria = new ContaBancaria() {
                         Conta = "65286",
                         Digito = "8",
                         AgenciaBancaria = new AgenciaBancaria() {
                             Agencia = "8223",
                             Digito = "9"
                         }
                     }
                 }
             };
             Clientes.Add(Cliente);
             Clientes.Add(Cliente2);*/

            List<Cliente> Clientes = new List<Cliente>() {
                new Cliente() {
                    CPF = "02826059408",
                     Nome = "ALEXSANDRA V C S MEDEIROS",
                     CobrancaAgendada = new List<Cobranca>() {
                         new Cobranca { Descricao = "CB - Teste" , Valor = 15f, Data = Convert.ToDateTime("03/10/2019"), NDocto = "080340000019900"},
                     },
                     ContaBancaria = new ContaBancaria() {
                         Conta = "09740",
                         Digito = "6",
                         AgenciaBancaria = new AgenciaBancaria() {
                             Agencia = "5633",
                             Digito = "6"
                         }
                     }
                }
            };

            Clientes.Add(Cliente2);

            /*
            StringBuilder StringB = Create.Shipping(Empresa, Clientes, (Bank)341, 1);
            Create.TxtFile(StringB, Banco);*/

            StringBuilder StringB2 = Create.Return(Empresa, Clientes, (Bank)341, 1);
            String FileName = Create.TxtFile(StringB2, Banco, false);

            RetornoCNAB240 Result = Read.Return(FileName);
            String a = "";

        }
    }
}
