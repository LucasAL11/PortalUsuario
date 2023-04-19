using PortalUsuario.Shared.Models;

namespace PortalUsuario.Data.Interfaces;

public interface IPesquisaDeSatisfacaoRepository
{
    Task<IndiceSatisfacaoModel> BuscarResultadoPesquisaDeSatisfacao();
    Task<IEnumerable<PesquisaSatisfacaoModel>> BuscarListaDePesquisaDeSatisfacao();
    Task<IEnumerable<PesquisaSatisfacaoModel>> BuscarPesquisaDeSatisfacao(string consultor);
    Task EnviarPesquisaDeSatisfacao(PesquisaSatisfacaoModel model);
    Task ReiniciarPesquisa();
}