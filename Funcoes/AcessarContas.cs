using SimuladorATM.Modelos;
using System.Text.Json;

namespace SimuladorATM.Funcoes;

internal class AcessarContas
{
    public static Dictionary<string, DadosConta> Execute()
    {
        string json = File.ReadAllText(@"Contas.json");
        return JsonSerializer.Deserialize<Dictionary<string, DadosConta>>(json)!;
    }
}
