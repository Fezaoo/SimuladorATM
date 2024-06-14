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
        Console.Write("Escolha uma opção: ");
        Console.Write("[1] Exibir todo extrato");
        Console.Write("[2] Exibir hoje");
        Console.Write("[3] Dia específico");
        Console.Write("Sua opção: ");
        string res = Console.ReadLine()!;

        ExibirSecao("Extrato");
        List<DadosTransacoes> transacoes = LinqFilter.FiltrarExtratoPorDia(conta.Conta);
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
