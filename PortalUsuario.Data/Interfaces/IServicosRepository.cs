using PortalUsuario.Shared.Models;

namespace PortalUsuario.Data.Interfaces;

public interface IServicosRepository
{
    Task<IEnumerable<ServicosModel>> Select(int codColigada);
}