using PortalUsuario.Shared.Models;

namespace PortalUsuario.Data.Interfaces;

public interface IAvisosRepository
{
    Task<IEnumerable<AvisosModel>> BuscarAvisos(bool isAdm);
    Task<AvisosModel> BuscarAvisoPorNSeq(int nSeq);
    Task<AvisosModel> BuscarArquivos(int nSeq);
    Task CadastrarAviso(AvisosModel model);
}