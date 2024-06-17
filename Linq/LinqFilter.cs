using SimuladorATM.Funcoes;
using SimuladorATM.Modelos;
using System.Collections.Generic;
using System.Transactions;

namespace SimuladorATM.Linq;

internal class LinqFilter
{
    public static List<DadosTransacoes> FiltrarExtratoPorConta(string conta)
    {
        Dictionary<string, DadosTransacoes> extrato = RegistroDeContas.ObterRegistroDadosTransacoes();
        var extratoFiltrado = extrato.Where(transacao => transacao.Value.ContaDestino!.Equals(conta) || transacao.Value.ContaOrigem!.Equals(conta)).Select(transacao => transacao.Value).ToList();
        return extratoFiltrado;
    }
    public static List<DadosTransacoes> FiltrarExtratoPorHoje(string conta)
    {
        string hoje = DateTime.Now.Date.ToString("d");
        Dictionary<string, DadosTransacoes> extrato = RegistroDeContas.ObterRegistroDadosTransacoes();
        List<DadosTransacoes> extratoFiltrado = extrato
            .Where(transacao =>
            (transacao.Value.ContaDestino != null && transacao.Value.ContaDestino.Equals(conta) ||
             transacao.Value.ContaOrigem != null && transacao.Value.ContaOrigem.Equals(conta)) &&
             transacao.Value.Data != null && transacao.Value.Data.Contains(hoje))
            .Select(transacao => transacao.Value)
            .ToList();
        return extratoFiltrado;
    }
    public static List<DadosTransacoes> FiltrarExtratoPorDia(string conta, string data)
    {
        var extrato = RegistroDeContas.ObterRegistroDadosTransacoes();
        var extratoFiltrado = extrato
            .Where(transacao => 
            (transacao.Value.ContaDestino != null && transacao.Value.ContaDestino.Equals(conta) ||
            transacao.Value.ContaOrigem != null && transacao.Value.ContaOrigem.Equals(conta)) &&
            transacao.Value.Data != null && transacao.Value.Data.Contains(data))
            .Select(transacao => transacao.Value)
            .ToList();
        return extratoFiltrado;
    }
}
