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
            contas[conta].Deposito(valor);
            DadosTransacoes Transacao = new()
            {
                NTransacao = "",
                Valor = valor,
                ContaDestino = conta,
                ContaOrigem = null,
                Tipo = "Depósito"
            };
            bool res = RegistroDeContas.EscreverNovoRegistro(contas, Transacao);
            if (res) { Mensagem.ExibirSucesso("Depósito realizado com sucesso!"); }
            else { Mensagem.ExibirFracasso("Ocorreu um erro ao realizar o depósito."); }
        }
        else
        {
            Console.WriteLine("Nenhuma conta foi encontrada! ");
        }
    }
}



