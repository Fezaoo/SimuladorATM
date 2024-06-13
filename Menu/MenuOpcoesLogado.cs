using SimuladorATM.Funcoes;
using SimuladorATM.Modelos;

namespace SimuladorATM.Menu;

internal class MenuOpcoesLogado : Menu
{
    public override void Execute(string nConta)
    {
        Dictionary<string, DadosConta> contas = RegistroDeContas.ObterRegistroDadosContas();
        DadosConta conta = contas[nConta];
        Dictionary<int, Menu> menus = new();
        menus.Add(1, new MenuExtrato());
        menus.Add(2, new MenuConsultarSaldo());
        menus.Add(3, new MenuTransferencia());
        Console.Clear();
        MenuOpcoesLogado.ExibirTitulo(conta.Titular!);
        Console.WriteLine();
        Console.WriteLine("Selecione uma opção: ");
        Console.WriteLine("[1] Extrato");
        Console.WriteLine("[2] Consultar Saldo");
        Console.WriteLine("[3] Transferência Bancária");
        Console.WriteLine("[0] Sair");

        Console.Write("Opção: ");
        int option = Convert.ToInt32(Console.ReadLine());
        switch (option)
        {

            case 0:
                Console.WriteLine("Saindo da Conta....");
                Thread.Sleep(1500);
                break;

            case 1:
                menus[1].Execute(conta);
                MenuExtrato meno = new();
                meno.Execute(conta);

                break;

            case 2:
                menus[2].Execute(conta);
                break;

            case 3:
                menus[3].Execute(conta);

                break;

            default:
                Console.WriteLine("Digite uma opção válida! ");
                Thread.Sleep(4000);
                break;
        }
        if (option != 0)
        {
            Console.Write("Aperte uma tecla para Voltar ao menu da conta");
            Console.ReadKey();
            Execute(conta.Conta);
        }
    }

}
