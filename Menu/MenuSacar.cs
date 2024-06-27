using SimuladorATM.Funcoes;
using SimuladorATM.Modelos;

namespace SimuladorATM.Menu;

internal class MenuSacar : Menu
{
    public override void Execute(DadosConta conta)
    {
        base.Execute(conta);
        var contas = RegistroDeContas.ObterRegistroDadosContas();
        ExibirSecao("Saque");
        Console.Write("Quanto deseja sacar? ");
        double valor = Convert.ToDouble(Console.ReadLine());
        if (conta.Saldo >= valor)
        {
            contas[Convert.ToString(conta.Conta!)].Sacar(valor);
            DadosTransacoes Transacao = new DadosTransacoes
            {
                NTransacao = "",
                Valor = valor,
                ContaDestino = null,
                ContaOrigem = Convert.ToString(conta.Conta!),
                Tipo = "Saque"
            };
            bool res = RegistroDeContas.EscreverNovoRegistro(contas, Transacao);
            if (res) { Mensagem.ExibirSucesso("Saque realizado com sucesso!"); }
            else { Mensagem.ExibirFracasso("Ocorreu um erro ao realizar o depósito."); }
        }
        else
        {
            Mensagem.ExibirFracasso("Você não possui saldo suficiente para esta transação!");
        }
    }
}
