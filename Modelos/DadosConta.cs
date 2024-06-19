using System.Text.Json.Serialization;

namespace SimuladorATM.Modelos;

internal class DadosConta
{

    [JsonPropertyName("titular")]
    public string? Titular { get; set; }

    [JsonPropertyName("senha")]
    public string? Senha
    {
        get { return _senha; }
        set { _senha = value!; }
    }
    private string? _senha;
    [JsonPropertyName("saldo")]
    public double Saldo 
    { 
        get { return _saldo; } 
        set { _saldo = value; } 
    }
    private double _saldo;

    [JsonPropertyName("agencia")]
    public string? Agencia { get; set; }
    [JsonPropertyName("conta")]
    public string? Conta { get; set; }

    public void Deposito(double novoSaldo)
    {
        if (novoSaldo > 0)
        {
            _saldo += novoSaldo;
        }
        else
        {
            throw new ArgumentException("A quantia deve ser maior que zero.");
        }
    }
    public void Sacar(double valor)
    {
        if (valor > 0 && valor <= _saldo)
        {
            _saldo -= valor;
        }
        else
        {
            throw new ArgumentException("A quantia deve ser maior que zero ou saldo insuficiente.");
        }
    }

}
