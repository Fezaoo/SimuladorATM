namespace SimuladorATM.Funcoes;

internal class Input
{
    public static int OpcaoNumerica()
    {
        string res;
        while (true)
        {
            Console.Write("Opção: ");
            res = Console.ReadLine()!;
            if (res == "" || !res.Any(char.IsDigit) || Convert.ToInt32(res) < 0)
            {
                Mensagem.ExibirFracasso("Digite uma opção válida! ");
                Thread.Sleep(2000);
            }
            else if (res.All(char.IsDigit))
            {
                break;
            }
        }
        int option = Convert.ToInt32(res);
        return option;
    }
}
