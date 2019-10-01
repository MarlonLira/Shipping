# Shipping - SDK C#

Projeto para envio e retorno de remessa bancarias.

# Descrição
Este pacote consiste em um SDK em C# para a geração de arquivos de remessa para fins de trabalho e estudo.

# Requisitos
- [.Net Framework 4.5](https://www.microsoft.com/pt-br/download/details.aspx?id=30653 ".Net Framework 4.5").

# Instalação
- Via Nuget

## Exemplo de implementação

> Exemplo do código de geração do arquivo de remessa CNAB 240 pelo banco Itau.

```C#

/* Lista da entidade Cliente
 */
List<Cliente> Clientes = new List<Cliente>() {
new Cliente() {
    CPF = "09266777450",
    Nome = "Dona Maria",
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
  }
}

/* Entidade Empresa
 */
 
 var Empresa = new Empresa() {
    CNPJ = "09055417000126",
    Nome = "Empresa"
    Codigo = "51840",
    Digito = "9",
    Juros = 0.5f,
    Mora = MoraTipo.JurosSimples,
    RetencaoIOF = IOF.Com,
    ContaBancaria = ContaBancaria = new ContaBancaria() {
        Conta = "68650",
        Digito = "6",
        AgenciaBancaria = new AgenciaBancaria()
        {
            Agencia = "9782",
            Digito = "2"
        }
    },
    Endereco = new Endereco() {
        Nome = "Estr. do Arraial",
        CEP = "52051380",
        Cidade = "Recife",
        Numero = 862,
        EstadoSigla = "PE",
        Tipo = "Predio"
    }
};
            
/* Método responsavel por gerar o arquivo de remessa, espera como parametro a entidade empresa,
 *  uma lista da entidade Cliente e o codigo do banco que será utilizado. O método retorna uma StringBuilder.
 */
var Result = Create.Shipping(Empresa, Clientes, (Bank)341);

```
## Em Construção...
