using PortalUsuario.Shared.DTO;
using PortalUsuario.Shared.Models;

namespace PortalUsuario.Data.Interfaces;

public interface IRatRepository
{
    Task Atualizar(RatModel model);
    Task<IEnumerable<RatModel>> Selecionar(ParametrosRatDTO parametros);
    Task FinalizarRat(int id);
    Task Inserir(RatModel ratModel);
    Task<IEnumerable<RatModel>> BuscarCamposDesabilitados(int id, string usuario);
    Task ReabriRat(int idRat);
    Task SelecionarPorIdFaturamento(int idRat);
    Task<IEnumerable<RatModel>> SelecionarRatPorId(int idRat);
    Task<IEnumerable<RelatorioPowerBiModel>> BuscarRelatoriosPbi();
    Task<IEnumerable<DespesaModel>> BuscarDespesa();
    Task<int> ContarQuantidadeRat(string codUsuario, int codColigada);
}