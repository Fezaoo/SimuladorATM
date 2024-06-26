﻿using SimuladorATM.Funcoes;
using SimuladorATM.Linq;
using SimuladorATM.Modelos;

namespace SimuladorATM.Menu;

internal class MenuExtrato : Menu
{
    public override void Execute(DadosConta conta)
    {
        base.Execute(conta);
        Console.Clear();
        List<DadosTransacoes> transacoes;
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
                transacoes = LinqFilter.FiltrarExtratoPorConta(conta.Conta!);
                break;

            case 2:
                transacoes = LinqFilter.FiltrarExtratoPorHoje(conta.Conta!);
                break;

            case 3:
                Console.Write("Digite o dia ou hora em que quer pesquisar o extrato: ");
                string data = Console.ReadLine()!;
                transacoes = LinqFilter.FiltrarExtratoPorDia(conta.Conta!, data);

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
            Console.WriteLine($"Data: {transacao.Data}");
            Console.WriteLine($"Tipo: {transacao.Tipo}");
            if (transacao.ContaOrigem == conta.Conta)
            {
                Console.Write($"Valor: ");
                Mensagem.ExibirFracasso((transacao.Valor * -1).ToString());
                Console.WriteLine($"Conta destino: {transacao.ContaDestino}");
            }
            else
            {
                Console.Write($"Valor: ");
                Mensagem.ExibirSucesso((transacao.Valor).ToString());
                Console.WriteLine($"Conta origem: {transacao.ContaOrigem}");
            }
            
        }
        
    }
}
