using Dispatch.Commons.Banks;
using Dispatch.Commons.Shipping;
using Library.Banks;
using Library.Commons;
using System;
using System.Collections.Generic;
using System.Text;
using static Library.Commons.Empresa;

namespace Dispatch
{
    class Program
    {
        static void Main(string[] args) {

            
            //const int numeroRegistro = 1;

            Itau Banco = new Itau();

            Endereco Endereco = new Endereco() {
                Nome= "Estr. do Arraial",
                CEP= "52051380",
                Cidade = "Recife",
                Numero = 2262,
                EstadoSigla = "PE",
                Tipo = "Academia"
            };

            Endereco Endereco2 = new Endereco() {
                Nome = "Estr. do Arraial",
                CEP = "52051380",
                Cidade = "Recife",
                Numero = 22,
                EstadoSigla = "PE",
                Tipo = "Casa"
            };

            ContaBancaria ContaBancaria = new ContaBancaria() {
                Conta = "79659",
                Digito = "6",
                AgenciaBancaria = new AgenciaBancaria() {
                    Agencia = "9632",
                    Digito = "2"
                }
            };

            ContaBancaria ContaBancariaCliente = new ContaBancaria() {
                Conta = "28170",
                Digito = "7",
                AgenciaBancaria = new AgenciaBancaria() {
                    Agencia = "6942",
                    Digito = "2"
                }
            };

            var Empresa = new Empresa() {
                CNPJ = "09055417000126",
                Nome = "HI ACADEMIA",
                Codigo = "50070",
                Digito = "9",
                OrigemDebito = "1524526352",
                ValorIDA = 500.10f,
                Mora = MoraTipo.IDA,
                ContaBancaria = ContaBancaria,
                Endereco = Endereco
            };

            var Cliente = new Cliente() {
                ContaBancaria = ContaBancariaCliente,
                CPF = "09855664580",
                Nome = "Arthur Polegadas",
                Endereco = Endereco2
            };

            List<Cliente> Clientes = new List<Cliente>() {
                new Cliente() {
                    CPF = "09266587450",
                    Nome = "Maria Benta",
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
                    CPF = "09266587450",
                    Nome = "Bernadino Pessoa",
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
                    CPF = "09266587450",
                    Nome = "Zumira Bernardo",
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
                }
            };
            Clientes.Add(Cliente);
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
