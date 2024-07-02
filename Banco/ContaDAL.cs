﻿using SimuladorATM.Modelos;

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
        context.Contas.Add(conta);
        context.SaveChanges();
    }
    public void Atualizar(DadosConta conta)
    {
        context.Contas.Update(conta);
        context.SaveChanges();
    }
    public void Deletar(DadosConta conta)
    {
        context.Contas.Update(conta);
        context.SaveChanges();
    }
    public DadosConta? Consultar(int conta)
    {
        return context.Contas.Find(conta);
    }
    public DadosConta? Consultar(DadosConta conta)
    {
        return context.Contas.Find(conta.ContaID);
    }
    public bool Existe(DadosConta conta)
    {
        return context.Contas.Find(conta.ContaID) is not null;
    }
    public bool Existe(int conta)
    {
        return context.Contas.Find(conta) is not null;
    }

}
