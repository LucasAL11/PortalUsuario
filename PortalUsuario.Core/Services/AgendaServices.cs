using System.Globalization;
using PortalUsuario.Core.Interfaces;
using PortalUsuario.Data.Repositories;
using PortalUsuario.Data.Interfaces;
using PortalUsuario.Shared.Models;
using PortalUsuario.Shared.DTO;


namespace PortalUsuario.Core.Services;

public class AgendaServices : IAgendaServices
{
    private readonly IAgendaRepository _repository;

    public AgendaServices(IAgendaRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<AgendaModel>> BuscarDados(ParametrosAgendaDTO parametrosAgendaDto)
    {
        var response = await _repository.BuscarDados(parametrosAgendaDto);

        return response;
    }


    public async Task<AgendaModel> BuscarEventoDoDia(DateTime data)
    {
        throw new NotImplementedException();
    }
    

    public Task BuscarClientes()
    {
        throw new NotImplementedException();
    }

    public Task BuscarContratos()
    {
        throw new NotImplementedException();
    }

    public Task BuscarRats()
    {
        throw new NotImplementedException();
    }

    public Task BuscarDadosRatSelecionado()
    {
        throw new NotImplementedException();
    }

    public Task BuscarPlacas()
    {
        throw new NotImplementedException();
    }

    public Task CriarRat()
    {
        throw new NotImplementedException();
    }

    public Task EditarRat()
    {
        throw new NotImplementedException();
    }
    
    public Task BuscarImagemPerfils()
    {
        throw new NotImplementedException();
    }

    public Task EnviarImagemPerfils()
    {
        throw new NotImplementedException();
    }
    
}