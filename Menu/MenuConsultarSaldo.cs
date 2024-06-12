using SimuladorATM.Modelos;

namespace SimuladorATM.Menu;

internal class MenuConsultarSaldo: Menu
{
    public override void Execute(DadosConta conta)
    {
        base.Execute(conta);
        Console.WriteLine($"Saldo: {conta.Saldo}");
        Thread.Sleep(2000);
    }
}
