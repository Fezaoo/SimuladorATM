using SimuladorATM.Banco;
using SimuladorATM.Funcoes;
using SimuladorATM.Modelos;

namespace SimuladorATM.Menu;

internal class MenuCriarConta : Menu
{
    public override void Execute(ContaDAL contaDAL)
    {
        base.Execute();
        ExibirTitulo("Criar Conta");
        Console.WriteLine();
        ExibirSecao("FORMULÁRIO");
        Console.WriteLine();
        Console.Write("Qual seu nome? [999 para sair]: ");
        string nome = Console.ReadLine()!;
        if (nome == "999") { return; }
        string senha;
        while (true) 
        {
        Console.Write("Qual será sua senha? [999 para sair]: ");
        senha = Console.ReadLine()!;
            if (!(senha.Length != 4 || !senha.All(char.IsDigit)))
            {
                break;
            }
            else if (senha == "999") { return; }
            else { Mensagem.ExibirFracasso("Digite uma senha com 4 dígitos Apenas números "); }
        }
        try
        {
            var conta = contaDAL.Adicionar(new DadosConta(nome, senha));
            Mensagem.ExibirSucesso("Conta criado com Sucesso!");
            Console.WriteLine($"O número da sua conta é: {conta.ContaID}");
        }
        catch
        {
            Mensagem.ExibirFracasso("Ocorreu um erro ao criar a conta! ");
            Thread.Sleep(2000);
        }
    }
}
