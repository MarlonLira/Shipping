using Library.Arquivos.CNAB240.Remessa;
using System;

namespace Library.Files
{
    public class WriteShipping {

        public class Itau {

            Banks.Itau BancoItau = new Banks.Itau();

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
                    File = File.WriteInLine(4, 7, "0000"); // CODIGO DO LOTE
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
                    File = File.RightEmptyLine(143, 172); // ENDEREÇO EMPRESA NOME DA RUA, AV, PÇA, ETC...
                    File = File.WriteInLine(173, 177, "1"); //  NÚMERO DO LOCAL
                    File = File.WriteInLine(178, 192, "DDMMAAAA"); //  CASA, APTO, SALA, ETC... 
                    File = File.WriteInLine(193, 212, "HHMMSS"); // NOME DA CIDADE
                    File = File.WriteInLine(213, 220, ""); // CEP
                    File = File.WriteInLine(221, 222, "040"); // SIGLA DO ESTADO 
                    File = File.LeftEmptyLine(223, 230); // BRANCOS
                    File = File.LeftEmptyLine(231, 240); // BRANCOS

                    Result = File;

                } catch {
                    throw;
                }

                return Result;
            }


            public String WriteHeaderDetails(HeaderRemessaCNAB240 Header) {
                String Result = "";
                String EmpresaNome = Header.EmpresaCedente.Nome;

                if (EmpresaNome.Length > 30) {
                    EmpresaNome = EmpresaNome.Substring(0, 30);
                }

                var File = new String(' ', 240);

                try { 


                    File = File.WriteInLine(1, 3, "341"); // CÓDIGO BANCO NA COMPENSAÇÃO
                    File = File.WriteInLine(4, 7, "0001"); // LOTE IDENTIFICAÇÃO DE SERVIÇO
                    File = File.WriteInLine(8, 8, "3"); // REGISTRO DETALHE DE LOTE
                    File = File.WriteInLine(9, 13, "00001"); // Nº SEQUENCIAL REGISTRO NO LOTE
                    File = File.WriteInLine(14, 14, "A"); // CÓDIGO SEGMENTO REG. DETALHE 
                    File = File.WriteInLine(15, 17, "000"); // CÓDIGO DA INSTRUÇÃO PARA MOVIMENTO | 000 = inclusão de debito | 999 = exlusão de debito
                    File = File.WriteInLine(18, 20, "000"); // CÓDIGO DA CÂMARA DE COMPENSAÇÃO
                    File = File.WriteInLine(21, 23, "341"); // CÓDIGO DO BANCO
                    File = File.WriteInLine(24, 24, "0"); // COMPLEMENTO DE REGISTROS
                    File = File.WriteInLine(25, 28, Header.ClienteSacado.ContaBancaria.AgenciaBancaria.Agencia); // Nº. AGÊNCIA DEBITADA
                    File = File.RightEmptyLine(29, 29); // COMPLEMENTO DE REGISTROS | BRANCOS
                    File = File.WriteInLine(30, 36, "0000000"); // COMPLEMENTO DE REGISTROS
                    File = File.WriteInLine(37, 41, Header.ClienteSacado.ContaBancaria.Conta); // NR. DA CONTA DEBITADA
                    File = File.RightEmptyLine(42, 42); // COMPLEMENTO DE REGISTROS
                    File = File.WriteInLine(43, 43, Header.ClienteSacado.ContaBancaria.Conta); // DIGITO VERIFICADOR DA AG/CONTA
                    File = File.WriteInLine(44, 73, Header.ClienteSacado.Nome.AddEmptyLine(44, 73)); // NOME DO DEBITADO
                    File = File.WriteInLine(74, 88, Header.EmpresaCedente.ContaBancaria.Conta); // NR. DO DOCUM. ATRIBUÍDO P/EMPRESA
                    File = File.RightEmptyLine(89, 93); // COMPLENTO DE REGISTROS | BRANCOS
                    File = File.WriteInLine(94, 101, "DDMMAAAA"); // DATA PARA O LANÇAMENTO DO DÉBITO 
                    File = File.WriteInLine(102, 104, BancoItau.Moeda); // TIPO DA MOEDA
                    File = File.WriteInLine(105, 119, "5".AddEmptyLine(105, 119)); // QUANTIDADE DA MOEDA OU IOF | IOF
                    File = File.WriteInLine(120, 134, "99,99".AddEmptyLine(120, 134)); // VALOR DO LANÇAMENTO PARA DÉBITO
                    File = File.RightEmptyLine(135, 154); // NR. DO DOCUM. ATRIBUÍDO PELO BANCO
                    File = File.RightEmptyLine(155, 162); //  DATA REAL DA EFETIVAÇÃO DO LANÇTO. 
                    File = File.RightEmptyLine(163, 177); // VALOR REAL DA EFETIVAÇÃO DO LANÇTO.
                    File = File.WriteInLine(178, 179, "00"); // TIPO DO ENCARGO POR DIA DE ATRASO | 00 = isento | 01 = juros simples | 03 = IDA (Importância por dia de atraso)
                    File = File.WriteInLine(180, 196, "00000000000000000"); // VALOR DO ENCARGO P/ DIA DE ATRASO
                    File = File.LeftEmptyLine(197, 212); // INFORMAÇÃO COMPL. P/ HISTÓRICO C/C
                    File = File.WriteInLine(213, 216, "Deb Autor".AddEmptyLine(213,216)); // COMPLEMENTO DE REGISTRO | BRANCO
                    File = File.WriteInLine(217, 230, Header.ClienteSacado.CPF); // Nº DE INSCRIÇÃO DO DEBITADO (CPF/CNPJ)
                    File = File.RightEmptyLine(231, 240); // CÓDIGO DAS OCORRÊNCIAS P/ RETORNO | BRANCOS

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

    public static String WriteInLine(this String Content, Int32 FromLine, Int32 ToLine, String Value) {
        Int32 Start = FromLine - 1;

        var SizeOfLine = ToLine - Start;
        if (Value.Length != SizeOfLine) {
            throw new Exception("Shipping: Valor a Preencher: " + Value +
                                " é diferente do tamanho do preenchimento informado. Posição inicial: " + FromLine +
                                " até " + ToLine);
        }

        // 1º remove
        Content = Content.Remove(Start, ToLine - FromLine);
        // 2º insere
        Content = Content.Insert(Start, Value);

        return Content;
    }

    public static String RightEmptyLine(this String Content, Int32 FromLine, Int32 ToLine) {
        Int32 Start = FromLine - 1;
        var SizeOfLine = ToLine - Start;

        // 1º remove
        Content = Content.Remove(Start, ToLine - FromLine);
        // 2º insere
        Content = Content.Insert(Start, string.Empty.PadRight(SizeOfLine, ' '));

        return Content;
    }

    public static String LeftEmptyLine(this String Content, Int32 FromLine, Int32 ToLine) {
        Int32 Start = FromLine - 1;
        var SizeOfLine = ToLine - Start;

        // 1º remove
        Content = Content.Remove(Start, ToLine - FromLine);
        // 2º insere
        Content = Content.Insert(Start, string.Empty.PadLeft(SizeOfLine, ' '));

        return Content;
    }

    public static String AddZeroLine(this String Content, Int32 FromLine, Int32 ToLine) {
        FromLine = FromLine + Content.Length;
        Int32 Start = FromLine - 1;
        var SizeOfLine = ToLine - Start;
        Content += new string('0', SizeOfLine);

        return Content;
    }

    public static String AddZeroLeftLine(this String Content, Int32 FromLine, Int32 ToLine) {
        FromLine = FromLine + Content.Length;
        Int32 Start = FromLine - 1;
        var SizeOfLine = ToLine - Start;
        Content = new string('0', SizeOfLine) + Content;

        return Content;
    }

    public static String AddEmptyLine(this String Content, Int32 FromLine, Int32 ToLine) {
        FromLine = FromLine + Content.Length;
        Int32 Start = FromLine - 1;
        var SizeOfLine = ToLine - Start;
        Content += new string(' ', SizeOfLine);

        return Content;
    }

}


