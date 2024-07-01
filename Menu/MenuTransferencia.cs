using SimuladorATM.Funcoes;
using SimuladorATM.Modelos;

namespace SimuladorATM.Menu;

internal class MenuTransferencia : Menu
{
    public override void Execute(DadosConta conta)
    {
        base.Execute(conta);
        var contas = RegistroDeContas.ObterRegistroDadosContas();
        ExibirSecao("Transferência");
        Console.WriteLine();
        Console.Write("Digite a conta que você quer transferir: ");
        string nContaDestino = Console.ReadLine()!;
        if (contas.ContainsKey(nContaDestino) && nContaDestino != Convert.ToString(conta.Conta!))
        {
            Console.Write("Insira o valor que deseja depositar: ");
            double valor = Convert.ToDouble(Console.ReadLine());
            if (conta.Saldo >= valor)
            {
                contas[nContaDestino].Deposito(valor);
                contas[Convert.ToString(conta.Conta!)].Saque(valor);
                DadosTransacoes Transacao = new DadosTransacoes
                {
                    NTransacao = "",
                    Valor = valor,
                    ContaDestino = nContaDestino,
                    ContaOrigem = Convert.ToString(conta.Conta!),
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
        else if (Convert.ToString(conta.Conta!) == nContaDestino)
        {
            Mensagem.ExibirFracasso("Você não pode transferir para si mesmo! ");
            Thread.Sleep(2000);
        }
        else
        {
            Mensagem.ExibirFracasso("Nenhuma conta foi encontrada! ");
            Thread.Sleep(2000);
        }

    }
}