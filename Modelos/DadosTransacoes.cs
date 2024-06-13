using System.Text.Json.Serialization;

namespace SimuladorATM.Modelos;

internal class DadosTransacoes
{
    [JsonPropertyName("n_transacao")]
    public string? NTransacao{ get; set; }
    [JsonPropertyName("tipo")]
    public string? Tipo{ get; set; }
    [JsonPropertyName("valor")]
    public double Valor { get; set; }
    [JsonPropertyName("data")]
    public string? Data { get; set; }
    [JsonPropertyName("conta_destino")]
    public string? ContaDestino { get; set; }
    [JsonPropertyName("conta_origem")]
    public string? ContaOrigem { get; set; }

}
