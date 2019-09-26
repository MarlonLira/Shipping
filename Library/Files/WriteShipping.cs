using Library.Arquivos.CNAB240.Remessa;
using System;

namespace Library.Files
{
    public class WriteShipping {

        public class Itau {
            public String WriteHeaderFile(HeaderRemessaCNAB240 Header) {
                String Result = "";
                String EmpresaNome = Header.EmpresaCedente.Nome;

                if (EmpresaNome.Length > 30) {
                    EmpresaNome = EmpresaNome.Substring(0, 30);
                }

                var File = new String(' ', 240);

                try {

                    File = File.WriteInLine(1, 3, "341"); // CODIGO BANCARIO
                    File = File.WriteInLine(4, 7, "0000"); // ZEROS
                    File = File.WriteInLine(8, 8, "0"); // ZERO
                    File = File.RightEmptyLine(9, 17); // BRANCOS
                    File = File.WriteInLine(18, 18, "2"); // TIPO DE INSCRIÇÃO DA EMPRESA | CPF = '1' | CNPJ =  '2'
                    File = File.WriteInLine(19, 32, Header.EmpresaCedente.CNPJ); //  NÚMERO DO CNPJ/CPF DA EMPRESA
                    File = File.WriteInLine(33, 45, Header.EmpresaCedente.Codigo); // CÓDIGO DO CONVÊNIO NO BANCO 
                    File = File.RightEmptyLine(46, 52); // BRANCOS 
                    File = File.WriteInLine(53, 53, "0"); // ZERO
                    File = File.WriteInLine(54, 57, Header.EmpresaCedente.ContaBancaria.AgenciaBancaria.Agencia); // AGENCIA REFERENTE CONVÊNIO ASSINADO 
                    File = File.RightEmptyLine(58, 58); // BRANCOS
                    File = File.WriteInLine(59, 65, "0000000"); // ZEROS
                    File = File.WriteInLine(66, 70, Header.ClienteSacado.ContaBancaria.Conta); // NÚMERO DA C/C DO CLIENTE
                    File = File.RightEmptyLine(71, 71); // BRANCOS
                    File = File.WriteInLine(72, 72, Header.ClienteSacado.ContaBancaria.AgenciaBancaria.Digito); // DAC (Dígito de Auto Conferência) DA AGÊNCIA/ CONTA. De quem ? Empresa ou Cliente?
                    File = File.WriteInLine(73, 102, Header.EmpresaCedente.Nome.AddEmptyLine(73, 102)); // NOME DA EMPRESA
                    File = File.WriteInLine(103, 132, "BANCO ITAU".AddEmptyLine(103, 132)); // NOME DO BANCO
                    File = File.RightEmptyLine(133, 142); // BRANCOS
                    File = File.WriteInLine(143, 143, "1"); //  CÓDIGO REMESSA = 1/RETORNO = 2
                    File = File.WriteInLine(144, 151, "DDMMAAAA"); //  DATA DE GERAÇÃO DO ARQUIVO
                    File = File.WriteInLine(152, 157, "HHMMSS"); // HORA DE GERAÇÃO DO ARQUIVO 
                    File = File.WriteInLine(158, 163, Convert.ToString(Header.SequencialNsa).AddZeroLeftLine(158, 163)); // NR. SEQUENCIAL DO ARQUIVO
                    File = File.WriteInLine(164, 166, "040"); // NR. DA VERSÃO DO LAYOUT
                    File = File.WriteInLine(167, 171, "00000"); // DENSIDADE DE GRAVAÇÃO DO ARQUIVO 
                    File = File.RightEmptyLine(172, 191); // PARA USO RESERVADO DO BANCO 
                    File = File.RightEmptyLine(192, 240); // BRANCOS

                    Result = File;

                } catch {
                    throw;
                }

                return Result;
            }

            public String WriteHeaderAllotment(HeaderRemessaCNAB240 Header) {
                String Result = "";
                String EmpresaNome = Header.EmpresaCedente.Nome;

                if (EmpresaNome.Length > 30) {
                    EmpresaNome = EmpresaNome.Substring(0, 30);
                }

                var File = new String(' ', 240);

                try {

                    File = File.WriteInLine(1, 3, "341"); // CODIGO BANCARIO
                    File = File.WriteInLine(4, 7, "0000"); // LOTE IDENTIFICAÇÃO DE SERVIÇO
                    File = File.WriteInLine(8, 8, "1"); // REGISTRO DO HEADER DO LOTE
                    File = File.WriteInLine(9, 9, "D"); // TIPO DA OPERAÇÃO
                    File = File.WriteInLine(10, 11, "05"); // FORMA DE LANÇAMENTO
                    File = File.WriteInLine(12, 13, "50"); // Nº DA VERSÃO DO LAYOUT 
                    File = File.WriteInLine(14, 16, "030"); // Nº DA VERSÃO DO LAYOUT 
                    File = File.RightEmptyLine(17, 17); // BRANCOS 
                    File = File.WriteInLine(18, 18, "2"); // TIPO DE INSCRIÇÃO DA EMPRESA | CPF = '1' | CNPJ =  '2'
                    File = File.WriteInLine(19, 32, Header.EmpresaCedente.CNPJ); // NÚMERO DO CNPJ/CPF DA EMPRESA
                    File = File.WriteInLine(33, 45, Header.EmpresaCedente.Codigo); // CÓDIGO DO CONVÊNIO NO BANCO 
                    File = File.RightEmptyLine(46, 52); // BRANCOS 
                    File = File.WriteInLine(53, 53, "0"); // ZERO
                    File = File.WriteInLine(54, 57, Header.EmpresaCedente.ContaBancaria.AgenciaBancaria.Agencia); // AGENCIA REFERENTE CONVÊNIO ASSINADO 
                    File = File.RightEmptyLine(58, 58); // BRANCOS
                    File = File.WriteInLine(59, 65, "0000000"); // ZEROS
                    File = File.WriteInLine(66, 70, Header.EmpresaCedente.ContaBancaria.Conta); // NÚMERO DA C/C DO CLIENTE
                    File = File.RightEmptyLine(71, 71); // BRANCOS
                    File = File.WriteInLine(72, 72, Header.EmpresaCedente.ContaBancaria.AgenciaBancaria.Digito); // DAC (Dígito de Auto Conferência) DA AGÊNCIA/ CONTA. De quem ? Empresa ou Cliente?
                    File = File.WriteInLine(73, 102, Header.EmpresaCedente.Nome.AddEmptyLine(73, 102)); // NOME DA EMPRESA
                    File = File.RightEmptyLine(103, 142); // BRANCOS
                    File = File.WriteInLine(143, 172, Header.EmpresaCedente.Endereco.Nome.AddEmptyLine(143,172)); // ENDEREÇO EMPRESA NOME DA RUA, AV, PÇA, ETC...
                    File = File.WriteInLine(173, 177, Header.EmpresaCedente.Endereco.Numero.AddEmptyLine(173, 177)); //  NÚMERO DO LOCAL
                    File = File.WriteInLine(178, 192, Header.EmpresaCedente.Endereco.Tipo.AddEmptyLine(178,192)); //  CASA, APTO, SALA, ETC... 
                    File = File.WriteInLine(193, 212, Header.EmpresaCedente.Endereco.Cidade.AddEmptyLine(193, 212)); // NOME DA CIDADE
                    File = File.WriteInLine(213, 220, Header.EmpresaCedente.Endereco.CEP.AddEmptyLine(213, 220)); // CEP
                    File = File.WriteInLine(221, 222, Header.EmpresaCedente.Endereco.EstadoSigla); // SIGLA DO ESTADO 
                    File = File.LeftEmptyLine(223, 230); // BRANCOS
                    File = File.LeftEmptyLine(231, 240); // BRANCOS

                    Result = File;

                } catch {
                    throw;
                }

                return Result;
            }

        }
    }
}

public static class Write
{

    public static String WriteInLine(this String Content, Int32 FromLine, Int32 ToLine, Object Value) {
        Int32 Start = FromLine - 1;
        String StringValue = Convert.ToString(Value);
        var SizeOfLine = ToLine - Start;
        if (StringValue.Length != SizeOfLine) {
            throw new Exception("Shipping: Valor a Preencher: " + Value +
                                " é diferente do tamanho do preenchimento informado. Posição inicial: " + FromLine +
                                " até " + ToLine);
        }

        // 1º remove
        Content = Content.Remove(Start, ToLine - FromLine);
        // 2º insere
        Content = Content.Insert(Start, StringValue);

        return Content;
    }

    public static String RightEmptyLine(this Object ContentEdit, Int32 FromLine, Int32 ToLine) {
        Int32 Start = FromLine - 1;
        var SizeOfLine = ToLine - Start;
        String Content = Convert.ToString(ContentEdit);

        // 1º remove
        Content = Content.Remove(Start, ToLine - FromLine);
        // 2º insere
        Content = Content.Insert(Start, string.Empty.PadRight(SizeOfLine, ' '));

        return Content;
    }

    public static String LeftEmptyLine(this Object ContentEdit, Int32 FromLine, Int32 ToLine) {
        Int32 Start = FromLine - 1;
        var SizeOfLine = ToLine - Start;
        String Content = Convert.ToString(ContentEdit);

        // 1º remove
        Content = Content.Remove(Start, ToLine - FromLine);
        // 2º insere
        Content = Content.Insert(Start, string.Empty.PadLeft(SizeOfLine, ' '));

        return Content;
    }

    public static String AddZeroLine(this Object ContentEdit, Int32 FromLine, Int32 ToLine) {
        String Content = Convert.ToString(ContentEdit);
        FromLine = FromLine + Content.Length;
        Int32 Start = FromLine - 1;
        var SizeOfLine = ToLine - Start;
        Content += new string('0', SizeOfLine);

        return Content;
    }

    public static String AddZeroLeftLine(this Object ContentEdit, Int32 FromLine, Int32 ToLine) {
        String Content = Convert.ToString(ContentEdit);
        FromLine = FromLine + Content.Length;
        Int32 Start = FromLine - 1;
        var SizeOfLine = ToLine - Start;
        Content = new string('0', SizeOfLine) + Content;

        return Content;
    }

    public static String AddEmptyLine(this Object ContentEdit, Int32 FromLine, Int32 ToLine) {
        String Content = Convert.ToString(ContentEdit);
        FromLine = FromLine + Content.Length;
        Int32 Start = FromLine - 1;
        var SizeOfLine = ToLine - Start;
        Content += new string(' ', SizeOfLine);

        return Content;
    }
}


