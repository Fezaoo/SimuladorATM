using SimuladorATM.Banco;
using SimuladorATM.Funcoes;
using SimuladorATM.Menu;

Dictionary<int,Menu>menus = new()
{
    { 1, new MenuDeposito() },
    { 2, new MenuCriarConta() },
    { 3, new MenuEntrarNaConta() }
};


void ExibirMenuInicial()
{
    var contaDAL = new ContaDAL(new SimuladorATMContext());
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
    int option = Input.OpcaoNumerica();
    
    switch (option)
    {
        case 0:
            Console.WriteLine("Tchau Tchau :)");
            break;

        case 1:
            menus[1].Execute(contaDAL);
            break;

        case 2:
            menus[2].Execute(contaDAL);
            break;

        case 3:
            menus[3].Execute(contaDAL);
            break;

        default:
            Mensagem.ExibirFracasso("Digite uma opção válida! ");
            Thread.Sleep(2000);
            break;
    }
    if (option != 0 && option != 3) 
    {
        Console.Write("Aperte uma tecla para Voltar ao menu principal");
        Console.ReadKey();
        ExibirMenuInicial(); 
    }
    else if (option == 3)
    {
        ExibirMenuInicial();
    }
}
ExibirMenuInicial();