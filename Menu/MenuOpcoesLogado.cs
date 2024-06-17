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

        int option = Input.OpcaoNumerica();
        switch (option)
        {

            case 0:
                Console.WriteLine("Saindo da Conta....");
                Thread.Sleep(1500);
                break;

            case 1:
                menus[1].Execute(conta);
                break;

            case 2:
                menus[2].Execute(conta);
                break;

            case 3:
                menus[3].Execute(conta);

                break;
            default:
                Mensagem.ExibirFracasso("Digite uma opção válida! ");
                Thread.Sleep(2000);
                break;
        }
        if (option > 0 && option < 4)
        {
            Console.Write("Aperte uma tecla para Voltar ao menu da conta");
            Console.ReadKey();
            Execute(conta.Conta);
        }
        else if (option != 0)
        {
            Execute(conta.Conta);
        }
    }

}
