using Library.Arquivos.CNAB240.Remessa;
using Library.Banks;
using Library.Commons;
using Library.Files;
using System;
using System.Collections.Generic;
using System.Text;

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
                Codigo = "9092409100012",
                Digito = "9",
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

            var CNB240 = new HeaderRemessaCNAB240(Empresa, Cliente, 10);

            var Itau = new WriteShipping.Itau();
            String Result;

            Result = Itau.WriteHeaderFile(CNB240);
            foreach (Cliente FoundClient in Clientes) {
                CNB240 = new HeaderRemessaCNAB240(Empresa, FoundClient, 10);
                Result += "|" + Itau.WriteHeaderAllotment(CNB240);
                Result += "|" + Itau.WriteHeaderDetails(CNB240);
                Result += "|" + Itau.WriteTrailerAllotment(CNB240);
            }

            Result += "|" + Itau.WriteTrailerFile(CNB240);

            String [] ResultPart = Result.Split('|');

            StringBuilder StringB = new StringBuilder();

            foreach (String File in ResultPart) {
                StringB.AppendLine(File);
            }

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
