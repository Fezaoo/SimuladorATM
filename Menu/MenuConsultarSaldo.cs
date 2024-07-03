using SimuladorATM.Banco;
using SimuladorATM.Funcoes;
using SimuladorATM.Modelos;

namespace SimuladorATM.Menu;

internal class MenuConsultarSaldo: Menu
{
    public override void Execute(int nConta)
    {
        base.Execute();
        var contaDAL = new ContaDAL(new SimuladorATMContext());
        var conta = contaDAL.Consultar(nConta);
        Console.Write("Saldo: ");
        if (conta!.Saldo < 0)
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
