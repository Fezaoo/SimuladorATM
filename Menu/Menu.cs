using SimuladorATM.Banco;
using SimuladorATM.Funcoes;
using SimuladorATM.Modelos;

namespace SimuladorATM.Menu;

internal abstract class Menu
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
    public virtual void Execute(DadosConta conta, ContaDAL contaDAL)
    {
        Console.Clear();
        ExibirTitulo(conta.Titular!);
    }
    public virtual void Execute(int nConta, ContaDAL contaDAL)
    {
        Console.Clear();
    }
    public virtual void Execute(int nConta)
    {
        Console.Clear();
    }
    public virtual void Execute(ContaDAL contaDAL) { }
    public virtual void ExibirSecao(string titulo)
    {
        string divisor = string.Empty.PadLeft(titulo.Length, '-');
        Console.WriteLine($"{divisor} {titulo} {divisor}");
    }
}
