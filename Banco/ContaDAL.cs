using SimuladorATM.Modelos;

namespace SimuladorATM.Banco;

internal class ContaDAL
{
    protected readonly SimuladorATMContext context;
    public ContaDAL(SimuladorATMContext context)
    {
        this.context = context;
    }

    public void Adicionar(DadosConta conta)
    {
        context.DadosContas.Add(conta);
        context.SaveChanges();
    }
    public void Atualizar(DadosConta conta)
    {
        context.DadosContas.Update(conta);
        context.SaveChanges();
    }
    public void Deletar(DadosConta conta)
    {
        context.DadosContas.Update(conta);
        context.SaveChanges();
    }
    public DadosConta? Consultar(int conta)
    {
        return context.DadosContas.Find(conta);
    }
    public DadosConta? Consultar(DadosConta conta)
    {
        return context.DadosContas.Find(conta.Conta);
    }
    public bool Existe(DadosConta conta)
    {
        return context.DadosContas.Find(conta.Conta) is not null;
    }
    public bool Existe(int conta)
    {
        return context.DadosContas.Find(conta) is not null;
    }

}
