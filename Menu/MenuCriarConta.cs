using SimuladorATM.Funcoes;
using SimuladorATM.Modelos;
using System.Text.Json;
using static System.Net.Mime.MediaTypeNames;

namespace SimuladorATM.Menu;

internal class MenuCriarConta : Menu
{
    public override void Execute()
    {
        base.Execute();
        ConsoleColor corOriginalTexto = Console.ForegroundColor;
        ConsoleColor corOriginalFundo = Console.BackgroundColor;
        Dictionary<string, DadosConta> json = RegistroDeContas.ObterRegistroDadosContas();
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
        Console.Write("Qual seu nome? [999 para sair]: ");
        string nome = Console.ReadLine()!;
        if (nome == "999") { return; }
        string senha;
        while (true) 
        {
        Console.Write("Qual será sua senha? [999 para sair]: ");
        senha = Console.ReadLine()!;
            if (!(senha.Length != 4 || !senha.All(char.IsDigit)))
            {
                break;
            }
            else if (senha == "999") { return; }
            else { Mensagem.ExibirFracasso("Digite uma senha com 4 dígitos Apenas números "); }
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
            Conta = Convert.ToInt32(nConta)
        });
        try
        {
            string newjson = JsonSerializer.Serialize(json, options);
            File.WriteAllText(path, newjson);
            Mensagem.ExibirSucesso("Conta criado com Sucesso!");
            
            
        }
        catch
        {
            Mensagem.ExibirFracasso("Ocorreu um erro ao criar a conta! ");
            Thread.Sleep(2000);
        }
    }
}
