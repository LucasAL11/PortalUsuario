using PortalUsuario.Shared.DTO;

namespace PortalUsuario.Core.Interfaces;

public interface IConsultoresServices
{
    Task<IEnumerable<ConsultorDTO>> GetAll();
}