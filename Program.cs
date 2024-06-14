using SimuladorATM.Funcoes;
using SimuladorATM.Menu;

Dictionary<int,Menu>menus = new();
menus.Add(1, new MenuDeposito());
menus.Add(2, new MenuCriarConta());
menus.Add(3, new MenuEntrarNaConta());

void ExibirMenuInicial()
{
    Console.Clear();

    Console.WriteLine(@"
░█████╗░████████╗███╗░░░███╗
██╔══██╗╚══██╔══╝████╗░████║
███████║░░░██║░░░██╔████╔██║
██╔══██║░░░██║░░░██║╚██╔╝██║
██║░░██║░░░██║░░░██║░╚═╝░██║
╚═╝░░╚═╝░░░╚═╝░░░╚═╝░░░░░╚═╝");
    Console.WriteLine();
    Console.WriteLine("Seja bem vindo ao atm, selecione uma opção: ");
    Console.WriteLine("[1] Depósito");
    Console.WriteLine("[2] Criar uma Conta");
    Console.WriteLine("[3] Entrar ");
    Console.WriteLine("[0] Sair");
    string res;
    while (true) 
    { 
        Console.Write("Opção: ");
        res = Console.ReadLine()!;
        if (res == "" || !res.Any(char.IsDigit))
        {
            Mensagem.ExibirFracasso("Digite uma opção válida! ");
            Thread.Sleep(3000);
        }
        else if (res.All(char.IsDigit))
        {
            break;
        }
    }
    int option = Convert.ToInt32(res);
    
    switch (option)
    {

        case 0:
            Console.WriteLine("Tchau Tchau :)");
            break;

        case 1:
            menus[1].Execute();
            break;

        case 2:
            menus[2].Execute();
            break;

        case 3:
            menus[3].Execute();
            break;

        default:
            Mensagem.ExibirFracasso("Digite uma opção válida! ");
            Thread.Sleep(4000);
            break;
    }
    if (option != 0 && option != 3) 
    {
        Console.Write("Aperte uma tecla para Voltar ao menu principal");
        Console.ReadKey();
        ExibirMenuInicial(); 
    }
    if (option == 3)
    {
        ExibirMenuInicial();
    }
}
ExibirMenuInicial();