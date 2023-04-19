using PortalUsuario.Core.Interfaces;
using PortalUsuario.Data.Interfaces;
using PortalUsuario.Data.Repositories;
using PortalUsuario.Shared.DTO;

namespace PortalUsuario.Core.Services;

public class ModulosServices : IModulosServices
{
    private readonly IModulosRepository _repository;

    public ModulosServices(IModulosRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<SistemasDTO>> BuscarModulos()
    {
        var sistemasModels = await _repository.GetFromDb();

        var sistemasDTO = new List<SistemasDTO>();
        var i = 0;
        foreach (var sistema in sistemasModels)
        {
            SistemasDTO sistemaDto;
            sistemaDto = new SistemasDTO
            {
                Key = i,
                CodSistema = sistema.CodSistema,
                Value = sistema.NomeSistema
            };

            i++;
            sistemasDTO.Add(sistemaDto);
        }

        return sistemasDTO;
    }
}