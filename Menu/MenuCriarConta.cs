using SimuladorATM.Funcoes;
using SimuladorATM.Modelos;
using System.Diagnostics;
using System.Text.Json;

namespace SimuladorATM.Menu;

internal class MenuCriarConta : Menu
{
    public override void Execute()
    {
        string path = @"C:\Users\Família Guimaraes\source\repos\Fezaoo\SimuladorATM\bin\Debug\net8.0\Contas.json";
        string newJson = File.ReadAllText(path);
        Dictionary<string, DadosConta> json = AcessarContas.Execute(true);
        string dado = JsonSerializer.Serialize(new DadosConta {
            Titular = "Felipe",
            Senha = "123",
            Agencia = "1",
            Saldo = 123.123
        });
        DadosConta dados = JsonSerializer.Deserialize<DadosConta>(dado)!;
        json.Add("123910", dados);
        Console.WriteLine(dados.Titular);
        File.WriteAllText(path, newJson);
        newJson = File.ReadAllText(path);
        Console.WriteLine(newJson);
        Console.ReadLine();
    }
}
