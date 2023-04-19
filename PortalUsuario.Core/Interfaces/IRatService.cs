using PortalUsuario.Shared.DTO;
using PortalUsuario.Shared.Models;

namespace PortalUsuario.Core.Interfaces;

public interface IRatService
{
    Task AtualizarRat(RatModel model);
    Task<IEnumerable<RatModel>> BuscarRats(ParametrosRatDTO parametros);
    Task FinalizarRat(int id);
    Task<IEnumerable<RatModel>> BuscarCamposDesabilitados(int id, string usuario);
    Task<int> BuscarQuantidadeDeRATS(string codUsuario, int codColigada);
    Task ReabriRat(int idRat);
    Task BuscarRatIdFaturamento(int idRat);
    Task<IEnumerable<RatDto>> BuscarRat(int idRat);
    Task<IEnumerable<RelatorioPowerBiDTO>> BuscarRelatoriosPbi();
    Task<IEnumerable<DespesaDTO>> BuscarDespesa();
    Task BuscarDadosRatSelecionado();
    Task CriarRat(RatModel ratModel);
    
}