using SimuladorATM.Banco;
using SimuladorATM.Funcoes;
using SimuladorATM.Modelos;
using SimuladorATM.Services;

namespace SimuladorATM.Menu;

internal class MenuTransferencia : Menu
{
    public override void Execute(DadosConta conta, ContaDAL contaDAL)
    {
        base.Execute(conta);
        var transacaoService = new TransacaoService(new SimuladorATMContext()); 
        ExibirSecao("Transferência");
        Console.WriteLine();
        int nContaDestino = Input.VerificacaoInt("Digite a conta que você quer transferir: ");
        if (contaDAL.Existe(nContaDestino))
        {
            Console.Write("Insira o valor que deseja depositar: ");
            double valor = Convert.ToDouble(Console.ReadLine());
            if (conta.Saldo >= valor)
            {
                var res = transacaoService.RealizarTransacaoAsync(nContaDestino, "Transferencia", valor, conta.ContaID);
                if (res.Result) { Mensagem.ExibirSucesso("Depósito realizado com sucesso!"); }
                else { Mensagem.ExibirFracasso("Ocorreu um erro ao realizar o depósito."); }
            }
            else
            {
                Mensagem.ExibirFracasso("Você não possui saldo suficiente para esta transação!");
            }
        }
        else if (conta.ContaID == nContaDestino)
        {
            Mensagem.ExibirFracasso("Você não pode transferir para si mesmo! ");
            Thread.Sleep(2000);
        }
        else
        {
            Mensagem.ExibirFracasso("Nenhuma conta foi encontrada! ");
            Thread.Sleep(2000);
        }
    }
}