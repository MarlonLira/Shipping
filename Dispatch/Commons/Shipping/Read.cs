using Library.Banks;
using Library.Commons;
using System;

namespace Dispatch.Commons.Shipping
{
    public static class Read {
        public static Retorno Return(String Path) {
            Retorno Return = new Retorno();
            String[] Lines;
            try {
                Lines = (!String.IsNullOrEmpty(Path)
                    ? System.IO.File.ReadAllLines(Path)
                    : throw new Exception("O caminho do arquivo não foi informado ou está incorreto!"));

                foreach (String FoundLine in Lines) {
                    Return = RetriveLine(FoundLine, Return);
                }

            } catch {
                throw;
            }

            return Return;
        }

        private static Retorno RetriveLine(String Line, Retorno Return) {
            Object Identity;
            Retorno Result = (Return != null
                ? Return
                : throw new Exception("O retorno não pode ser nulo!"));

            Identity = Convert.ToInt32(Line.RetriveOnLine(8, 8));
            switch ((IsFile)Identity) {
                case IsFile.HeaderFile: {

                        Result.Banco = new Itau(false);
                        Result.Banco.Codigo = Line.RetriveOnLine(1, 3); // CODIGO BANCARIO
                        Result.TipoInscricaoEmp = Convert.ToInt32(Line.RetriveOnLine(18, 18)); // TIPO DE INSCRIÇÃO DA EMPRESA | CPF = '1' | CNPJ =  '2'
                        Result.Empresa.CNPJ = Line.RetriveOnLine(19, 32); // NÚMERO DO CNPJ/CPF DA EMPRESA
                        Result.Empresa.Convenio = Line.RetriveOnLine(33, 45).Trim(); // CÓDIGO DO CONVÊNIO NO BANCO
                        Result.Empresa.ContaBancaria.AgenciaBancaria.Agencia = Line.RetriveOnLine(54, 57); // AGENCIA REFERENTE CONVÊNIO ASSINADO 
                        Result.Empresa.ContaBancaria.Conta = Line.RetriveOnLine(66, 70); // NÚMERO DA C/C DO CLIENTE
                        Result.Empresa.ContaBancaria.Digito = Line.RetriveOnLine(72, 72); // DAC (Dígito de Auto Conferência) DA AGÊNCIA/ CONTA.
                        Result.Empresa.Nome = Line.RetriveOnLine(73, 102); // NOME DA EMPRESA
                        Result.Banco.Nome = Line.RetriveOnLine(103, 132).Trim(); // NOME DO BANCO
                        Result.CodigoRR = Line.RetriveOnLine(143, 143); //  CÓDIGO REMESSA = 1/RETORNO = 2
                        Result.DataGeracao = Line.RetriveOnLine(144, 151); //  DATA DE GERAÇÃO DO ARQUIVO
                        Result.HoraGeracao = Line.RetriveOnLine(152, 157); // HORA DE GERAÇÃO DO ARQUIVO 
                        Result.SequencialArquivo = Line.RetriveOnLine(158, 163); // NR. SEQUENCIAL DO ARQUIVO 
                        Result.VLayout = Line.RetriveOnLine(164, 166); // NR. DA VERSÃO DO LAYOUT

                        break;
                    }
                case IsFile.HeaderAllotment: {

                        break;
                    }
                case IsFile.DetailsAllotment: {

                        break;
                    }
                case IsFile.TrailerAllotment: {

                        break;
                    }
                case IsFile.TrailerFile: {

                        break;
                    }
            }

            return Result;
        }
    }

    public static class Retrive{
        public static String RetriveOnLine(this Object ContentEdit, Int32 FromLine, Int32 ToLine) {
            String Result = Convert.ToString(ContentEdit);
            Int32 Start = FromLine - 1;
            Int32 SizeOfLine = ToLine - Start;
            Result = Result.Substring(Start, SizeOfLine);
            return Result;
        }

        public static String RemoveAndResize(this Object ContentEdit, Int32 Size, Boolean IsNumeric = false) {
            String Result = Convert.ToString(ContentEdit);
            String Identity = "";
            Int32 Count = 0;
            if (Result.Length > Size) {

                switch (IsNumeric) {
                    case true: {
                            while (Result.Length > Size) {
                                Identity = Result.Substring(Count, 1);
                                if (Convert.ToInt32(Identity) == 0) {
                                    Result = Result.Substring(Count, Size);
                                }
                                Count++;
                            }
                            break;
                        }
                    case false: {

                            break;
                        }

                }

            }

            return Result;
        }
    }

    public enum IsFile
    {
        HeaderFile = 0,
        HeaderAllotment = 1,
        DetailsAllotment = 3,
        TrailerAllotment = 5,
        TrailerFile = 9
    }

}
