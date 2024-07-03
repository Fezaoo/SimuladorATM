using SimuladorATM.Banco;
using SimuladorATM.Funcoes;
using SimuladorATM.Modelos;
using System.Text.Json;

namespace SimuladorATM.Menu;

internal class MenuEntrarNaConta : Menu
{
    public override void Execute(ContaDAL contaDAL)
    {
        base.Execute();
        ExibirTitulo("Entrar na Conta");
        Console.WriteLine();
        int nConta = Input.VerificacaoInt("Numero da Conta: ");
        if (contaDAL.Existe(nConta))
        {
            Console.Write("Insira sua senha: ");
            string senha = Console.ReadLine()!;
            var contaAcessada = contaDAL.Consultar(nConta);
            if (contaAcessada!.Senha!.Equals(senha))
            {
                Console.WriteLine($"Seja bem vindo {contaAcessada.Titular}");
                Console.WriteLine("Acessando Conta.....");
                Thread.Sleep(2000);
                MenuOpcoesLogado menuLogado = new MenuOpcoesLogado();
                menuLogado.Execute(contaAcessada.ContaID);
            }
            else 
            {
                Mensagem.ExibirFracasso("Conta ou Senha incorreta");
                Thread.Sleep(2000);
            }
        }
        else 
        {
            Mensagem.ExibirFracasso("Nenhuma conta foi encontrada! ");
            Thread.Sleep(2000);
        }


    }
}
