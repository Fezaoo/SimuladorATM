﻿using Microsoft.EntityFrameworkCore;
using SimuladorATM.Banco;
using SimuladorATM.Funcoes;
using SimuladorATM.Modelos;
using System.Linq.Expressions;
using System.Transactions;

namespace SimuladorATM.Services;

internal class TransacaoService
{
    private readonly SimuladorATMContext _context;

    public TransacaoService(SimuladorATMContext context)
    {
        _context = context;
    }

    public async Task<bool> RealizarTransacaoAsync(int contaId, string tipoTransacao, double valor, int contaOrigemID = 0)
    {
        using (var transaction = await _context.Database.BeginTransactionAsync()) 
        {
            try
            {
                var contaDAL = new ContaDAL(new SimuladorATMContext());
                var conta = contaDAL.Consultar(contaId);
                var transacao = new DadosTransacao()
                {
                    ContaID = contaId,
                    TipoTransacao = tipoTransacao,
                    Valor = valor,
                    DataHora = DateTime.Now
                };
                if (conta == null)
                {
                    Mensagem.ExibirFracasso("Conta não encontrada");
                    return false;
                }
                if (tipoTransacao == "Saque" && conta.Saldo < valor)
                {
                    Mensagem.ExibirFracasso("Saldo Insuficiente");
                    return false;
                }

                if (tipoTransacao == "Saque")
                {
                    transacao.ContaOrigemID = contaId;
                    conta.Saque(valor);
                    _context.Contas.Update(conta);
                }
                else if (tipoTransacao == "Deposito")
                {
                    conta.Deposito(valor);
                    _context.Contas.Update(conta);
                }
                else if (tipoTransacao == "Transferencia")
                {
                    var contaOrigem = contaDAL.Consultar(contaOrigemID);
                    conta.Deposito(valor);
                    contaOrigem!.Saque(valor);
                    _context.Update(conta);
                    _context.Update(contaOrigem);
                    transacao.ContaOrigemID = contaOrigemID;
                }
                _context.Transacoes.Add(transacao);
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
                return true;
            }
            catch (Exception e)
            {
                await Console.Out.WriteLineAsync(e.Message);
                await transaction.RollbackAsync();
                return false;
            }
        }

    }
}
