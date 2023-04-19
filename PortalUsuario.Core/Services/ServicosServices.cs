using PortalUsuario.Core.Interfaces;
using PortalUsuario.Data.Interfaces;
using PortalUsuario.Shared.DTO;

namespace PortalUsuario.Core.Services;

public class ServicosServices : IServicosServices
{
    private readonly IServicosRepository _repository;

    public ServicosServices(IServicosRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<ServicosDTO>> Buscar(int codColigada)
    {
        var servicosModels = await _repository.Select(codColigada);

        var servicosDto = new List<ServicosDTO>();

        foreach (var servico in servicosModels)
        {
            var servicoDto = new ServicosDTO
            {
                key = servico.key,
                CodProcesso = servico.CodProcesso,
                Descricao = servico.Descricao
            };

            servicosDto.Add(servicoDto);
        }

        return servicosDto;
    }
}