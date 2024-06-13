using SimuladorATM.Funcoes;
using SimuladorATM.Modelos;
using System.Diagnostics;
using System.Text.Json;

namespace SimuladorATM.Menu;

internal class MenuCriarConta : Menu
{
    public override void Execute()
    {
        base.Execute();
        ConsoleColor corOriginalTexto = Console.ForegroundColor;
        ConsoleColor corOriginalFundo = Console.BackgroundColor;
        Dictionary<string, DadosConta> json = AcessarContas.Execute(false);
        string path = @"C:\Users\fegui\OneDrive\Área de Trabalho\Curso em Vídeo\C#\Projetos\SimuladorATM\SimuladorATM\bin\Debug\net8.0\Contas.json";
        var options = new JsonSerializerOptions
        {
            Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            WriteIndented = true
        };

        ExibirTitulo("Criar Conta");
        Console.WriteLine();
        ExibirSecao("FORMULÁRIO");
        Console.WriteLine();
        Console.Write("Qual seu nome? ");
        string nome = Console.ReadLine()!;
        string senha;
        while (true) 
        {
        Console.Write("Qual será sua senha? [4 dígitos]: ");
        senha = Console.ReadLine()!;
            if (!(senha.Length < 4 || senha.Length > 4 || !senha.All(char.IsDigit))) 
            {
                break;
            }
            else { Console.WriteLine("Digite uma senha com 4 dígitos Apenas números "); }
        }

        string nConta = "";
        while (true)
        {
            Random random = new();
            for (int i = 0; i < 5; i++)
            {
                nConta += Convert.ToString(random.Next(9));
            }
            if (!json.ContainsKey(Convert.ToString(nConta)!)) { break; }
        }

        Console.WriteLine($"Sua conta possui número de conta: {nConta}");
        json.Add(nConta, new DadosConta
        {
            Titular = nome,
            Senha = senha,
            Agencia = "1",
            Saldo = 0
        });
        try
        {
            string newjson = JsonSerializer.Serialize(json, options);
            File.WriteAllText(path, newjson);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Conta criado com Sucesso!");
            Console.ForegroundColor = corOriginalTexto;
            
        }
        catch
        {
            Console.WriteLine("Ocorreu um erro ao criar a conta! ");
        }
    }
}
