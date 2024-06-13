using SimuladorATM.Funcoes;
using SimuladorATM.Modelos;
using System.Text.Json;
using System.Threading.Channels;

namespace SimuladorATM.Menu;

internal class MenuDeposito : Menu
{
    public override void Execute()
    {
        base.Execute();
        ExibirTitulo("Depósito");
        Console.Write("Numero da Conta: ");
        string conta = Console.ReadLine()!;
        Dictionary<string, DadosConta> contas = RegistroDeContas.ObterRegistroDadosContas();
        if (contas.ContainsKey(conta))
        {
            DadosConta contaAcessada = contas[conta];
            Console.Write("Quanto deseja depositar? ");
            double valor = Convert.ToInt32(Console.ReadLine());
            double novoSaldo = valor + contaAcessada.Saldo;
            contas[conta].Saldo = novoSaldo;
            DadosTransacoes Transacao = new DadosTransacoes
            {
                NTransacao = "",
                Valor = valor,
                ContaDestino = conta,
                ContaOrigem = null,
                Tipo = "Depósito"
            };
            bool res = RegistroDeContas.EscreverNovoRegistro(contas, Transacao);
            if (res) { Mensagens.ExibirSucesso("Depósito realizado com sucesso!"); }
            else { Mensagens.ExibirFracasso("Ocorreu um erro ao realizar o depósito."); }
        }
        else
        {
            Console.WriteLine("Nenhuma conta foi encontrada! ");
        }
    }
}



