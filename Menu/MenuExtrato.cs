using SimuladorATM.Banco;
using SimuladorATM.Funcoes;
using SimuladorATM.Linq;
using SimuladorATM.Modelos;

namespace SimuladorATM.Menu;

internal class MenuExtrato : Menu
{
    public override void Execute(DadosConta conta)
    {
        base.Execute(conta);
        Console.Clear();
        List<DadosTransacao> transacoes = new();
        var transacoesDAL = new TransacoesDAL(new SimuladorATMContext());
        Console.WriteLine();
        Console.WriteLine("Escolha uma opção: ");
        Console.WriteLine("[0] Sair");
        Console.WriteLine("[1] Exibir todo extrato");
        Console.WriteLine("[2] Exibir hoje");
        Console.WriteLine("[3] Dia específico");
        int option = Input.OpcaoNumerica();
        switch (option)
        {
            case 0:
                Console.WriteLine("Saindo...");
                Thread.Sleep(1500);
                return;
            case 1:
                transacoes = transacoesDAL.ConsultarExtratoPorConta(conta);
                break;

            case 2:
                transacoes = transacoesDAL.ConsultarExtratoPorHoje(conta);
                break;

            case 3:
                var data = new int[3];
                data[0] = Input.VerificacaoInt2Digitos("Digite o dia em que quer pesquisar o extrato: [dd] ");
                data[1] = Input.VerificacaoInt2Digitos("Digite o mês em que quer pesquisar o extrato: [mm] ");
                data[2] = Input.VerificacaoInt4Digitos("Digite o ano em que quer pesquisar o extrato: [aaaa] ");
                transacoes = transacoesDAL.ConsultarExtratoPorDia(conta, data);
                break;

            default:
                Mensagem.ExibirFracasso("Digite uma opção válida! ");
                Thread.Sleep(1000);
                return;
        }
        ExibirSecao("Extrato");
        foreach (var transacao in transacoes)
        {
            Console.WriteLine();
            Console.WriteLine($"Data: {transacao.DataHora}");
            Console.WriteLine($"Tipo: {transacao.TipoTransacao}");
            if (transacao.ContaOrigemID == conta.ContaID)
            {
                Console.Write($"Valor: ");
                Mensagem.ExibirFracasso((transacao.Valor * -1).ToString());
                Console.WriteLine($"Conta destino: {transacao.ContaID}");
            }
            else
            {
                Console.Write($"Valor: ");
                Mensagem.ExibirSucesso((transacao.Valor).ToString());
                Console.WriteLine($"Conta origem: {transacao.ContaOrigemID}");
            }
            
        }
        
    }
}
