namespace PortalUsuario.Shared.Models;

public class DespesaModel
{
    public int Id { get; set; }
    public string Consultor { get; set; }
    public string NomeConsultor { get; set; }
    public DateTime Data { get; set; }
    public DateTime? DataInicial { get; set; }
    public DateTime? DataFinal { get; set; }
    public string Tipo { get; set; }
    public double KM { get; set; }
    public double Valor { get; set; }
    public double Saldo { get; set; }
}