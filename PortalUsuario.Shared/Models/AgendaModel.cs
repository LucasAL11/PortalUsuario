namespace PortalUsuario.Shared.Models;

public class AgendaModel 
{
    public int Id { get; set; }
    public int IdRat { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public string Subject { get; set; }
    public bool? IsAllDay { get; set; } = true;
    public string Status { get; set; }
    public string CodUsuario { get; set; }
    public int Cor { get; set; }
    public int HomeOffice { get; set; }
    public string ImageProfile { get; set; }
    public string Nome { get; set; }
}