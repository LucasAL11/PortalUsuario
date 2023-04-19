using PortalUsuario.Shared.Enum;

namespace PortalUsuario.Shared.DTO;

public class ParametrosAgendaDTO
{
    public DateTime DataInicial { get; set; }
    public DateTime DataFim { get; set; }
    public string ValorBusca { get; set; }
    public bool HomeOffice { get; set; }
    public bool Interno { get; set; }
    public bool Externo { get; set; }
    public bool Ausente { get; set; }
    
    public ETipoDeBusca TipoDeBusca { get; set; }
}