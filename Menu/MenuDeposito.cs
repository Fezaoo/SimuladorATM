using SimuladorATM.Banco;
using SimuladorATM.Funcoes;
using SimuladorATM.Modelos;
using SimuladorATM.Services;
using System.Text.Json;
using System.Threading.Channels;

namespace SimuladorATM.Menu;

internal class MenuDeposito : Menu
{
    public override void Execute(ContaDAL contaDAL)
    {
        base.Execute();
        ExibirTitulo("Depósito");
        int nConta = Input.VerificacaoInt("Numero da Conta: ");
        if (contaDAL.Existe(nConta))
        {
            var conta = contaDAL.Consultar(nConta);
            double valor = Input.VerificacaoDouble("Quanto deseja depositar? ");
            var transacao = new TransacaoService(new SimuladorATMContext());
            var result = transacao.RealizarTransacaoAsync(conta!.Conta, "Deposito", valor);
            if (result.Result) { Mensagem.ExibirSucesso("Depósito realizado com sucesso!"); }
            else { Mensagem.ExibirFracasso("Ocorreu um erro ao realizar o depósito."); }
        }
        else
        {
            Console.WriteLine("Nenhuma conta foi encontrada! ");
        }
    }
}



