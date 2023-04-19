using PortalUsuario.Shared.DTO;

namespace PortalUsuario.Core.Interfaces;

public interface IPesquisaDeSatisfacaoService
{
    Task EnviarPesquisaDeSatisfacao(PesquisaSatisfacaoDTO dto);
    Task ReiniciarPesquisa();
    Task<IndiceSatisfacaoDTO> BuscarResultadoPesquisaDeSatisfacao();
    Task<IEnumerable<PesquisaSatisfacaoDTO>> BuscarListaDePesquisaDeSatisfacao();
    Task<IEnumerable<PesquisaSatisfacaoDTO>> BuscarPesquisaDeSatisfacao(string consultor);
}