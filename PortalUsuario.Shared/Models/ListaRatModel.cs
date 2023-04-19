namespace PortalUsuario.Shared.Models;

public sealed class ListaRatModel
{
    public int NSeq { get; set; }
    public string Status { get; set; }
    public string Usuario { get; set; }
    public string CodUsuario { get; set; }
    public string Tipo { get; set; }
    public string CodContrato { get; set; }
    public string Observacao { get; set; }
    public DateTime Data { get; set; }
}