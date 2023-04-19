using PortalUsuario.Shared.DTO;

namespace PortalUsuario.Core.Interfaces;

public interface IAvisosServices
{
    Task<IEnumerable<AvisoDto>> BuscarAvisos(bool isAdm);
    Task CadastrarAviso(AvisoDto model);
    Task EditarAviso();
    Task EnviarArquivosAviso();
    Task<AvisoDto> BuscarAvisoPorId(int nSeq);
    Task<AvisoDto> BuscarArquivos(int NSeq);
}