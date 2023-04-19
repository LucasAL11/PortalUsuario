using PortalUsuario.Shared.DTO;

namespace PortalUsuario.Core.Interfaces;

public interface IServicosServices
{
    Task<IEnumerable<ServicosDTO>> Buscar(int codColigada);
}

