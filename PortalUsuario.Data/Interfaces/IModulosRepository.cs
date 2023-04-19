using PortalUsuario.Shared.Models;

namespace PortalUsuario.Data.Interfaces;

public interface IModulosRepository
{
    Task<IEnumerable<SistemasModel>> GetFromDb();
}