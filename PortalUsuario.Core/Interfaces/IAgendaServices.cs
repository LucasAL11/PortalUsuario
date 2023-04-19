using PortalUsuario.Shared.DTO;
using PortalUsuario.Shared.Models;

namespace PortalUsuario.Core.Interfaces;

public interface IAgendaServices
{
    Task<IEnumerable<AgendaModel>> BuscarDados(ParametrosAgendaDTO parametrosAgendaDto);
    Task<AgendaModel> BuscarEventoDoDia(DateTime data);
    Task BuscarClientes();
    Task BuscarContratos();
    Task BuscarPlacas();
    Task BuscarImagemPerfils();
    Task EnviarImagemPerfils();
}