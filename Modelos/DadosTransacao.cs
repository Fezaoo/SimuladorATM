using System.ComponentModel.DataAnnotations;

namespace SimuladorATM.Modelos;

internal class DadosTransacao
{
    [Key]
    public int TransacaoID { get; set; }
    public int ContaID { get; set; }
    public string? TipoTransacao { get; set; }
    public double Valor { get; set; }
    public DateTime DataHora { get; set; }

}
