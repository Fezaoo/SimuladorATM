using SimuladorATM.Banco;
using SimuladorATM.Funcoes;
using SimuladorATM.Modelos;
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
            conta!.Deposito(valor);
            DadosTransacao Transacao = new()
            {
                NTransacao = "",
                Valor = valor,
                ContaDestino = "",
                ContaOrigem = null,
                Tipo = "Depósito"
            };
            if (true) { Mensagem.ExibirSucesso("Depósito realizado com sucesso!"); }
            else { Mensagem.ExibirFracasso("Ocorreu um erro ao realizar o depósito."); }
        }
        else
        {
            Console.WriteLine("Nenhuma conta foi encontrada! ");
        }
    }
}



