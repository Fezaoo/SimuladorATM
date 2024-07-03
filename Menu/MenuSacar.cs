using SimuladorATM.Banco;
using SimuladorATM.Funcoes;
using SimuladorATM.Modelos;
using SimuladorATM.Services;

namespace SimuladorATM.Menu;

internal class MenuSacar : Menu
{
    public override void Execute(DadosConta conta)
    {
        base.Execute(conta);
        var transacaoService = new TransacaoService(new SimuladorATMContext());
        ExibirSecao("Saque");
        Console.Write("Quanto deseja sacar? ");
        double valor = Convert.ToDouble(Console.ReadLine());
        if (conta.Saldo >= valor)
        {
            var res = transacaoService.RealizarTransacaoAsync(conta.ContaID, "Saque", valor);
            if (res.Result) { Mensagem.ExibirSucesso("Saque realizado com sucesso!"); }
            else { Mensagem.ExibirFracasso("Ocorreu um erro ao realizar o depósito."); }
        }
        else
        {
            Mensagem.ExibirFracasso("Você não possui saldo suficiente para esta transação!");
            Thread.Sleep(1000);
        }
    }
}
