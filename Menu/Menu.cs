using SimuladorATM.Funcoes;
using SimuladorATM.Modelos;

namespace SimuladorATM.Menu;

internal class Menu
{
    public static void ExibirTitulo(string titulo)
    {
        string divisor = string.Empty.PadLeft(titulo.Length, '=');
        Console.WriteLine(divisor);
        Console.WriteLine(titulo);
        Console.WriteLine(divisor);
    }
    public virtual void Execute()
    {
        Console.Clear();
    }
    public virtual void Execute(DadosConta conta)
    {
        Console.Clear();
        ExibirTitulo(conta.Titular!);
    }
    public virtual void Execute(string conta)
    {
        Console.Clear();
        Dictionary<string, DadosConta> contas = RegistroDeContas.ObterRegistroDadosContas();
        ExibirTitulo(contas[conta].Titular!);
    }
    public virtual void ExibirSecao(string titulo)
    {
        string divisor = string.Empty.PadLeft(titulo.Length, '-');
        Console.WriteLine($"{divisor} {titulo} {divisor}");
    }
}
