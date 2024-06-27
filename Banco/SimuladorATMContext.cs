using Microsoft.EntityFrameworkCore;
using SimuladorATM.Modelos;

namespace SimuladorATM.Banco;


internal class SimuladorATMContext : DbContext
{
    public DbSet<DadosConta> DadosContas { get; set; }
    public DbSet<DadosTransacao> DadosTransacao { get; set; }

    private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=SimuladorATM;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseSqlServer(connectionString);
    }
}
