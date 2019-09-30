﻿using Dispatch.Commons.Banks;
using Dispatch.Commons.Shipping;
using Library.Banks;
using Library.Commons;
using System;
using System.Collections.Generic;
using System.Text;
using static Library.Commons.Cliente;
using static Library.Commons.Empresa;

namespace Dispatch
{
    class Program {
        static void Main(string[] args) {

            Itau Banco = new Itau();

            Endereco Endereco = new Endereco() {
                Nome = "Estr. do Arraial",
                CEP = "52051380",
                Cidade = "Recife",
                Numero = 2262,
                EstadoSigla = "PE",
                Tipo = "Academia"
            };

            ContaBancaria ContaBancaria = new ContaBancaria() {
                Conta = "79659",
                Digito = "6",
                AgenciaBancaria = new AgenciaBancaria() {
                    Agencia = "9632",
                    Digito = "2"
                }
            };

            var Empresa = new Empresa() {
                CNPJ = "09055417000126",
                Nome = "CENTRO DE EST E FISIO INSPIRACAO",
                Codigo = "50070",
                Digito = "9",
                Juros = 1.5f,
                Mora = MoraTipo.JurosSimples,
                RetencaoIOF = IOF.Com,
                PctIOF = 3.4f,
                ContaBancaria = ContaBancaria,
                Endereco = Endereco
            };

            var Cliente = new Cliente() {
                CPF = "09665664580",
                Nome = "Arthur Polegadas",
                CobrancaAgendada = new List<Cobranca>() {
                    new Cobranca { Descricao = "Parcela" , Valor = 1014f, Data = Convert.ToDateTime("25/01/2020") }
                },
                QtdRegsLote = 3,
                ContaBancaria = new ContaBancaria() {
                    Conta = "28170",
                    Digito = "7",
                    AgenciaBancaria = new AgenciaBancaria() {
                        Agencia = "6942",
                        Digito = "2"
                    },
                },
                Endereco = new Endereco() {
                    Nome = "Estr. do Arraial",
                    CEP = "52051380",
                    Cidade = "Recife",
                    Numero = 22,
                    EstadoSigla = "PE",
                    Tipo = "Casa"
                }
            };

            var Cliente2 = new Cliente() {
                CPF = "09177350480",
                Nome = "Marlon Lira",
                CobrancaAgendada = new List<Cobranca>() {
                    new Cobranca { Descricao = "Parcela" , Valor = 59.9f, Data = Convert.ToDateTime("25/01/2020"), PctIOF = 0.8f },
                    new Cobranca { Descricao = "Parcela" , Valor = 59.9f, Data = Convert.ToDateTime("25/02/2020"), PctIOF = 0.8f },
                    new Cobranca { Descricao = "Parcela" , Valor = 59.9f, Data = Convert.ToDateTime("25/03/2020"), PctIOF = 0.8f },
                    new Cobranca { Descricao = "Parcela" , Valor = 59.9f, Data = Convert.ToDateTime("25/04/2020"), PctIOF = 0.8f },
                    new Cobranca { Descricao = "Parcela" , Valor = 59.9f, Data = Convert.ToDateTime("25/05/2020"), PctIOF = 0.8f },
                    new Cobranca { Descricao = "Parcela" , Valor = 59.9f, Data = Convert.ToDateTime("25/06/2020"), PctIOF = 0.8f },
                    new Cobranca { Descricao = "Parcela" , Valor = 59.9f, Data = Convert.ToDateTime("25/07/2020"), PctIOF = 0.8f },
                    new Cobranca { Descricao = "Parcela" , Valor = 59.9f, Data = Convert.ToDateTime("25/08/2020"), PctIOF = 0.8f },
                    new Cobranca { Descricao = "Parcela" , Valor = 59.9f, Data = Convert.ToDateTime("25/09/2020"), PctIOF = 0.8f },
                    new Cobranca { Descricao = "Parcela" , Valor = 59.9f, Data = Convert.ToDateTime("25/10/2020"), PctIOF = 0.8f },
                    new Cobranca { Descricao = "Parcela" , Valor = 59.9f, Data = Convert.ToDateTime("25/11/2020"), PctIOF = 0.8f },
                    new Cobranca { Descricao = "Parcela" , Valor = 59.9f, Data = Convert.ToDateTime("25/12/2020"), PctIOF = 0.8f }
                },
                QtdRegsLote = 3,
                ContaBancaria = new ContaBancaria() {
                    Conta = "58765",
                    Digito = "9",
                    AgenciaBancaria = new AgenciaBancaria() {
                        Agencia = "6985",
                        Digito = "3"
                    },
                },
                Endereco = new Endereco() {
                    Nome = "R. Democrito de Souza Filho",
                    CEP = "54150080",
                    Cidade = "Jaboatão",
                    Numero = 187,
                    EstadoSigla = "PE",
                    Tipo = "Casa"
                }
            };

            List<Cliente> Clientes = new List<Cliente>() {
                new Cliente() {
                    CPF = "09266777450",
                    Nome = "Maria Benta",
                    CobrancaAgendada = new List<Cobranca>() {
                        new Cobranca { Descricao = "Taxa" , Valor = 19.99f, Data = Convert.ToDateTime("25/09/2019"), PctIOF = 0.1f },
                        new Cobranca { Descricao = "Parcela" , Valor = 114f, Data = Convert.ToDateTime("25/10/2019"), PctIOF = 0.1f }
                    },
                    ValorAgendado = 114f,
                    QtdRegsLote = 3,
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
                    ValorAgendado = 99f,
                    QtdRegsLote = 3,
                    
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
                    new Cobranca { Descricao = "Taxa" , Valor = 19.90f, Data = Convert.ToDateTime("07/05/2020") },
                    new Cobranca { Descricao = "Parcela" , Valor = 69f, Data = Convert.ToDateTime("07/04/2020")}
                    },
                    ValorAgendado = 69f,
                    QtdRegsLote = 3,
                    
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
                    ValorAgendado = 69f,
                    QtdRegsLote = 3,

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
            Clientes.Add(Cliente2);

            StringBuilder StringB = Create.Shipping(Empresa, Clientes, (Bank)341);
			
            var path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var data = DateTime.Now.ToString("d").Replace("/", "");
            var nomeArquivo = string.Format("{0}{1}{2}{3}{4}{5}{6}", Banco.Codigo, "-", Banco.Nome, "_", data, @"_HEADER", ".txt");
            var arquivo = new System.IO.StreamWriter(path + @"\" + nomeArquivo, true);
            arquivo.Write(StringB);
            Console.WriteLine(StringB);
            Console.ReadKey();
            arquivo.Close();
        }
    }
}
