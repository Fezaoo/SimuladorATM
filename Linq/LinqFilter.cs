using SimuladorATM.Funcoes;
using SimuladorATM.Modelos;
using System.Collections.Generic;

namespace SimuladorATM.Linq;

internal class LinqFilter
{
    public static List<DadosTransacoes> FiltrarExtratoPorContaDestino(string conta)
    {
        Dictionary<string, DadosTransacoes> extrato = RegistroDeContas.ObterRegistroDadosTransacoes();
        var extratoFiltrado = extrato.Where(transacao => transacao.Value.ContaDestino!.Equals(conta) || transacao.Value.ContaOrigem!.Equals(conta)).Select(transacao => transacao.Value).ToList();
        return extratoFiltrado;
    }
}
