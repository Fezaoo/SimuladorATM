using SimuladorATM.Modelos;
using System.Text.Json;

namespace SimuladorATM.Menu;

internal class MenuEntrarNaConta : Menu
{
    public override void Execute()
    {
        base.Execute();
        ExibirTitulo("Entrar na Conta");
        Console.WriteLine();
        Console.Write("Numero da Conta: ");
        string conta = Console.ReadLine()!;
        string json = File.ReadAllText(@"C:\Users\fegui\OneDrive\Área de Trabalho\Curso em Vídeo\C#\Projetos\SimuladorATM\SimuladorATM\bin\Debug\net8.0\Contas.json");
        Dictionary<string, DadosConta> contas = JsonSerializer.Deserialize<Dictionary<string, DadosConta>>(json)!;
        if (contas.ContainsKey(conta))
        {
            Console.Write("Insira sua senha: ");
            string senha = Console.ReadLine()!;
            if (contas[conta].Senha!.Equals(senha))
            {
                DadosConta contaAcessada = contas[conta];
                Console.WriteLine($"Seja bem vindo {contaAcessada.Titular}");
                Console.WriteLine("Acessando Conta.....");
                Thread.Sleep(2000);
                MenuOpcoesLogado menuLogado = new MenuOpcoesLogado();
                menuLogado.Execute(contaAcessada);
            }
            else 
            { 
                Console.WriteLine("Acess Denied");
            }
        }
        else 
        {
            Console.WriteLine("Nenhuma conta foi encontrada! ");
        }


    }
}
