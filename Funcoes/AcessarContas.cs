using SimuladorATM.Modelos;
using System.Text.Json;

namespace SimuladorATM.Funcoes;

internal class AcessarContas
{
    public static Dictionary<string, DadosConta> Execute(bool notebook = false)
    {
        string json;
        if (notebook)
        {
             json = File.ReadAllText(@"C:\Users\Família Guimaraes\source\repos\Fezaoo\SimuladorATM\bin\Debug\net8.0\Contas.json");
        }
        else 
        {
            json = File.ReadAllText(@"C:\Users\fegui\OneDrive\Área de Trabalho\Curso em Vídeo\C#\Projetos\SimuladorATM\SimuladorATM\bin\Debug\net8.0\Contas.json");
        }
        return JsonSerializer.Deserialize<Dictionary<string, DadosConta>>(json)!;
    }
}
