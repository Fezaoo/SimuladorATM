using SimuladorATM.Funcoes;
using SimuladorATM.Modelos;

namespace SimuladorATM.Menu;

internal class MenuTransferencia : Menu
{
    public override void Execute(DadosConta conta)
    {
        base.Execute();
        Dictionary<string, DadosConta> contas = RegistroDeContas.ObterRegistroDadosContas();
        ExibirTitulo(conta.Titular!);
        ExibirSecao("Transferência");
        Console.WriteLine();
        Console.Write("Digite a conta que você quer transferir: ");
        string nContaDestino = Console.ReadLine()!;
        if (contas.ContainsKey(nContaDestino))
        {
            Console.Write("Insira o valor que deseja depositar: ");
            double valor = Convert.ToDouble(Console.ReadLine());
            if (conta.Saldo >= valor)
            {
                contas[nContaDestino].Deposito(valor);
                contas[conta.Conta!].Sacar(valor);
                DadosTransacoes Transacao = new DadosTransacoes
                {
                    NTransacao = "",
                    Valor = valor,
                    ContaDestino = nContaDestino,
                    ContaOrigem = conta.Conta,
                    Tipo = "Transferência bancária"
                };
                bool res = RegistroDeContas.EscreverNovoRegistro(contas, Transacao);
                if (res) { Mensagem.ExibirSucesso("Depósito realizado com sucesso!"); }
                else { Mensagem.ExibirFracasso("Ocorreu um erro ao realizar o depósito."); }
            }
            else
            {
                Mensagem.ExibirFracasso("Você não possui saldo suficiente para esta transação!");
            }
        }
        else
        {
            Mensagem.ExibirFracasso("Nenhuma conta foi encontrada! ");
            Thread.Sleep(2000);
        }

    }
}