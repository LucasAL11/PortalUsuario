using PortalUsuario.Shared.DTO;

namespace PortalUsuario.Core.Interfaces;

public interface IModulosServices
{
    Task<IEnumerable<SistemasDTO>> BuscarModulos();
}