using SimuladorATM.Funcoes;
using SimuladorATM.Linq;
using SimuladorATM.Modelos;

namespace SimuladorATM.Menu;

internal class MenuExtrato : Menu
{
    public override void Execute(DadosConta conta)
    {
        base.Execute(conta);
        Console.WriteLine();
        ExibirSecao("Extrato");
        List<DadosTransacoes> transacoes = LinqFilter.FiltrarExtratoPorContaDestino(conta.Conta);
        foreach (var transacao in transacoes)
        {
            Console.WriteLine();
            Console.WriteLine($"Data: {transacao.Data}");
            Console.WriteLine($"Tipo: {transacao.Tipo}");
            if (transacao.ContaOrigem == conta.Conta)
            {
                Console.Write($"Valor: ");
                Mensagem.ExibirFracasso((transacao.Valor * -1).ToString());
                Console.WriteLine($"Conta destino: {transacao.ContaDestino}");
            }
            else
            {
                Console.Write($"Valor: ");
                Mensagem.ExibirSucesso((transacao.Valor).ToString());
                Console.WriteLine($"Conta origem: {transacao.ContaOrigem}");
            }
            
        }
    }
}
