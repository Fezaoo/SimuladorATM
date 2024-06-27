namespace SimuladorATM.Modelos;

internal class DadosTransacao
{
    //[TransacaoID] INT IDENTITY(1, 1) NOT NULL,
    //[ContaID]       INT NOT NULL,
    //[TipoTransacao] VARCHAR(50)    NOT NULL,
    //[Valor]         DECIMAL(10, 2) NULL,
    //[DataHora]

    public int TransacaoID { get; set; }
    public int ContaID { get; set; }
    public string? TipoTransacao { get; set; }
    public double Valor { get; set; }
    public DateTime DataHora { get; set; }

}
