using System.Text.Json.Serialization;

namespace SimuladorATM.Modelos;

internal class DadosConta
{
    [JsonPropertyName("titular")]
    public string? Titular { get; set; }

    [JsonPropertyName("senha")]
    public string? Senha { get; set; }
    [JsonPropertyName("saldo")]
    public double Saldo { get; set; }
    [JsonPropertyName("agencia")]
    public string? Agencia { get; set; }
}
