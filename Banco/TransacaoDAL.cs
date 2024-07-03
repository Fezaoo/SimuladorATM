using SimuladorATM.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimuladorATM.Banco
{
    internal class TransacaoDAL 
    {
        private readonly SimuladorATMContext _context;
        public TransacaoDAL(SimuladorATMContext context)
        {
            _context = context;
        }
        public async void AdicionarAsync(DadosTransacao transacao)
        {
            _context.Transacoes.Add(transacao);
            await _context.SaveChangesAsync();
        }
        public void Adicionar(DadosTransacao transacao)
        {
            _context.Transacoes.Add(transacao);
            _context.SaveChanges();    
        }
        public void Atualizar(DadosTransacao transacao)
        {
            _context.Transacoes.Update(transacao);
            _context.SaveChanges();
        }
        public void Deletar(DadosTransacao transacao)
        {
            _context.Transacoes.Remove(transacao);
            _context.SaveChanges();
        }
        public List<DadosTransacao> ConsultarExtratoPorConta(DadosConta conta)
        {
            return _context.Transacoes
                .Where(a => a.ContaID == conta.ContaID || a.ContaOrigemID == conta.ContaID)
                .ToList();
        }

        public List<DadosTransacao> ConsultarExtratoPorHoje(DadosConta conta)
        {
            var data = DateTime.Now.Date;
            return ConsultarExtratoPorConta(conta)
                .Where(a => a.DataHora.Date
                .Equals(data))
                .ToList();
        }
        public List<DadosTransacao> ConsultarExtratoPorDia(DadosConta conta, int[] data)
        {
            var dia = new DateTime(data[2], data[1], data[0]);
            return ConsultarExtratoPorConta(conta)
                .Where(a => a.DataHora.Date
                .Equals(dia))
                .ToList();
        }
    }
}
