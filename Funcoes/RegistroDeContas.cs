using SimuladorATM.Modelos;
using System.Text.Json;

namespace SimuladorATM.Funcoes;

internal class RegistroDeContas
{
    private static string dadosContaPath = @"Contas.json";
    private static string transacoesPath = @"Transacoes.json";
    public static Dictionary<string, DadosConta> ObterRegistroDadosContas()
    {
        string json = File.ReadAllText(dadosContaPath);
        return JsonSerializer.Deserialize<Dictionary<string, DadosConta>>(json)!;
    }

    public static Dictionary<string, DadosTransacoes> ObterRegistroDadosTransacoes()
    {
        string json = File.ReadAllText(transacoesPath);
        
        return JsonSerializer.Deserialize<Dictionary<string, DadosTransacoes>>(json)!;
    } 

    public static bool EscreverNovoRegistro(Dictionary<string, DadosConta> contas, DadosTransacoes Transacao)
    {
        var options = new JsonSerializerOptions
        {
            Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            WriteIndented = true
        };
        try
        {
            string newJson = JsonSerializer.Serialize(contas, options);
            File.WriteAllText(dadosContaPath, newJson);

            Dictionary<string, DadosTransacoes> jsonTransacoes = ObterRegistroDadosTransacoes();
            string nTransacao = "";
            while (true)
            {
                Random random = new();
                for (int i = 0; i < 20; i++)
                {
                    nTransacao += Convert.ToString(random.Next(9));
                }
                if (!jsonTransacoes.ContainsKey(Convert.ToString(nTransacao)!)) 
                {
                    Transacao.NTransacao = nTransacao;
                    Transacao.Data = DateTime.Now.ToString();
                    break; 
                }
            }

            jsonTransacoes.Add(nTransacao, Transacao);
            string newJsonTransacao = JsonSerializer.Serialize(jsonTransacoes, options);
            File.WriteAllText(transacoesPath, newJsonTransacao);
        }
        catch (Exception ex)
        {
            Mensagem.ExibirFracasso("Ocorreu um erro: ");
            Console.WriteLine(ex.Message);
            return false;
        }
        return true;
    }
}
