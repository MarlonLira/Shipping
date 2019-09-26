using Library.Arquivos.CNAB240.Remessa;
using Library.Bancos.Itau;
using Library.Commons;
using Library.Files;
using System;

namespace Dispatch
{
    class Program
    {
        static void Main(string[] args) {

            
            //const int numeroRegistro = 1;

            Itau Banco = new Itau();

            ContaBancaria ContaBancaria = new ContaBancaria() {
                Conta = "79659-6",
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
                ContaBancaria = ContaBancaria
            };

            var Cliente = new Cliente() {
                ContaBancaria = ContaBancariaCliente,
                CPF = "09855664580",
                Nome = "Arthur Polegadas"
            };

            var CNB240 = new HeaderRemessaCNAB240(Empresa, Cliente, 1);

            var Itau = new WriteShipping.Itau();

            var WriteLine = Itau.WriteHeader(CNB240);

            var path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            var data = DateTime.Now.ToString("d").Replace("/", "");

            var nomeArquivo = string.Format("{0}{1}{2}{3}{4}{5}{6}", Banco.Codigo, "-", Banco.Nome, "_", data, @"_HEADER", ".txt");

            var arquivo = new System.IO.StreamWriter(path + @"\" + nomeArquivo, true);
            arquivo.Write(WriteLine);

            arquivo.Close();
        }
    }
}
