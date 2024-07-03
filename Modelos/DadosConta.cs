using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SimuladorATM.Modelos;

internal class DadosConta
{
    [Key]
    public int ContaID
    {
        get; set;
    }

    public string? Titular { get; set; }

    public string? Senha
    {
        get { return _senha; }
        set { _senha = value!; }
    }
    private string? _senha;
    public double Saldo 
    { 
        get { return _saldo; } 
        set { _saldo = value; } 
    }
    private double _saldo;

    public string? Agencia { get; set; }

    public DadosConta(string titular, string senha)
    {
        Titular = titular;
        Senha = senha;
        Saldo = 0;
        Agencia = "1";
    }


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
    public void Saque(double valor)
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
