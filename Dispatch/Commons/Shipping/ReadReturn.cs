using Dispatch.Commons.Banks;
using Library.Banks;
using Library.Commons;
using System;


namespace Dispatch.Commons.Shipping {
    public class ReadReturn {

        //public String ReturnTxt(String Path) {

        //    string lines = System.IO.File.ReadAllText(Path);

        //    return lines;

        //}

        public static String[] ReturnTxtPart(String Path) {

            string[] lines = System.IO.File.ReadAllLines(Path);

            return lines;

        }

        public static Return ReturnData(String Path) {
            Return Data = new Return();

            String[] Retorno = ReturnTxtPart(Path);
            Int32 LastLine = Retorno.Length - 1;

            String HeaderFile = Retorno[0];

            ControlHeaderFile(HeaderFile, Data, (Bank)341);

            String TrailerFile = Retorno[LastLine];


            return Data;
        }

        private static void ControlHeaderFile(String HeaderFile, Return Data, Bank Banco) {

            switch (Banco) {
                case Bank.Itau: {
                        Data.Banco = new Itau();
                        Data.Empresa = new Empresa();
                        Data.Empresa.ContaBancaria = new ContaBancaria();
                        Data.Empresa.ContaBancaria.AgenciaBancaria = new AgenciaBancaria();

                        Data.Banco.Codigo = HeaderFile.Substring(0, 3);
                        Data.TipoInscricaoEmp = Convert.ToInt32(HeaderFile.Substring(17, 1));
                        Data.Empresa.CNPJ = HeaderFile.Substring(18, 14);
                        Data.Empresa.Convenio = HeaderFile.Substring(32, 13).Trim();
                        Data.Empresa.ContaBancaria.AgenciaBancaria.Agencia = HeaderFile.Substring(53, 4);
                        Data.Empresa.ContaBancaria.Conta = HeaderFile.Substring(65, 5);
                        Data.Empresa.ContaBancaria.Digito = HeaderFile.Substring(71, 1);
                        Data.Empresa.Nome = HeaderFile.Substring(71, 30).Trim();
                        Data.Banco.Nome = HeaderFile.Substring(72, 30).Trim();



                        break;
                    }

            }
            



        }


    }
}
