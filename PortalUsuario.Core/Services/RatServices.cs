using PortalUsuario.Core.Interfaces;
using PortalUsuario.Data.Interfaces;
using PortalUsuario.Shared.DTO;
using PortalUsuario.Shared.Models;

namespace PortalUsuario.Core.Services;

public class RatServices : IRatService
{
    private readonly IRatRepository _repository;

    public RatServices(IRatRepository repository)
    {
        _repository = repository;
    }

    public async Task AtualizarRat(RatModel model)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<RatModel>> BuscarRats(ParametrosRatDTO parametros)
    {
        //ok
        var responseModel = await _repository.Selecionar(parametros);

        //falta implmentar
        //var dto = responseModel.ToDTO();

        return responseModel;
    }

    public async Task FinalizarRat(int idRat)
    {
        await _repository.FinalizarRat(idRat);
    }

    public async Task<IEnumerable<RatModel>> BuscarCamposDesabilitados(int id, string usuario)
    {
        var result = await _repository.BuscarCamposDesabilitados(id, usuario);
        return result;
    }

    public async Task<int> BuscarQuantidadeDeRATS(string codUsuario, int codColigada)
    {
        var response = await _repository.ContarQuantidadeRat(codUsuario, codColigada);
        return response;
    }
    
    public async Task ReabriRat(int idRat)
    {
        throw new NotImplementedException();
    }

    public async Task BuscarRatIdFaturamento(int idRat)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<RatDto>> BuscarRat(int idRat)
    {
        throw new NotImplementedException();
    }


    public async Task<IEnumerable<RelatorioPowerBiDTO>> BuscarRelatoriosPbi()
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<DespesaDTO>> BuscarDespesa()
    {
        throw new NotImplementedException();
    }

    public async Task BuscarDadosRatSelecionado()
    {
        throw new NotImplementedException();
    }

    public async Task CriarRat(RatModel ratModel)
    {
        await _repository.Inserir(ratModel);
    }
}