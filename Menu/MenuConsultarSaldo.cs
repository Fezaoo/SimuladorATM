using SimuladorATM.Funcoes;
using SimuladorATM.Modelos;

namespace SimuladorATM.Menu;

internal class MenuConsultarSaldo: Menu
{
    public override void Execute(DadosConta conta)
    {
        base.Execute(conta);
        Console.Write("Saldo: ");
        if (conta.Saldo < 0)
        {
            Mensagem.ExibirFracasso($" {conta.Saldo}");
        }
        else 
        {
        Mensagem.ExibirSucesso($"{conta.Saldo}");
        }
        Thread.Sleep(2000);
    }
}
