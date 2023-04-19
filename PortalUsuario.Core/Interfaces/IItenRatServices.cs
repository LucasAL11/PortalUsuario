using PortalUsuario.Shared.DTO;

namespace PortalUsuario.Core.Interfaces;

public interface IItenRatServices
{
    Task<IEnumerable<RatItensDto>> BuscarItensRat(int id);
    Task<RatItensDto> BucarItemRatUnico(int idRat, int sequencia);
    Task<IEnumerable<TipoRatDTO>> BucarListaTiposRat();
    Task AdicionarItem(RatItensDto dto);
    Task EditarItemRat(RatItensDto item);
    Task<bool> RemoverItemRat(int id, int sequencia);
    Task<bool> AtualizarHorarioItemRat(int idRat, decimal horario);
}
    
