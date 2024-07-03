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
    public static int VerificacaoInt(string mensagem)
    {
        string res;
        while (true)
        {
            Console.Write(mensagem);
            res = Console.ReadLine()!;
            if (res == "" || !res.Any(char.IsDigit) || Convert.ToInt32(res) < 0)
            {
                Mensagem.ExibirFracasso("Digite um valor válido! ");
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
    public static int VerificacaoInt4Digitos(string mensagem)
    {
        string res;
        while (true)
        {
            Console.Write(mensagem);
            res = Console.ReadLine()!;
            if (res == "" || !res.Any(char.IsDigit) || Convert.ToInt32(res) < 0 || res.Length != 4)
            {
                Mensagem.ExibirFracasso("Digite um valor válido! ");
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
    public static int VerificacaoInt2Digitos(string mensagem)
    {
        string res;
        while (true)
        {
            Console.Write(mensagem);
            res = Console.ReadLine()!;
            if (res == "" || !res.Any(char.IsDigit) || Convert.ToInt32(res) < 0 || res.Length != 2)
            {
                Mensagem.ExibirFracasso("Digite um valor válido! ");
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

    public static double VerificacaoDouble(string mensagem)
    {
        string res;
        while (true)
        {
            Console.Write(mensagem);
            res = Console.ReadLine()!;
            if (res == "" || !res.Any(char.IsDigit) || Convert.ToDouble(res) < 0)
            {
                Mensagem.ExibirFracasso("Digite um valor válido! ");
                Thread.Sleep(2000);
            }
            else if (res.All(char.IsDigit))
            {
                break;
            }
        }
        double option = Convert.ToDouble(res);
        return option;
    }

}
