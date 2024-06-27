using Microsoft.EntityFrameworkCore;
using SimuladorATM.Banco;
using SimuladorATM.Modelos;

namespace SimuladorATM.Services;

internal class TransacaoService
{
    private readonly DbContext _context;

    public TransacaoService(SimuladorATMContext context)
    {
        this._context = context;
    }

    public async Task<bool> RealizarTransacaoAsync(DadosTransacao dadosTransacao)
    {
    
    }


}
