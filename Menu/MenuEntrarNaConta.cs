using SimuladorATM.Funcoes;
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
        string json = File.ReadAllText(@"Contas.json");
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
                menuLogado.Execute(Convert.ToString(contaAcessada.ContaID!));
            }
            else 
            {
                Mensagem.ExibirFracasso("Conta ou Senha incorreta");
                Thread.Sleep(2000);
            }
        }
        else 
        {
            Mensagem.ExibirFracasso("Nenhuma conta foi encontrada! ");
            Thread.Sleep(2000);
        }


    }
}
