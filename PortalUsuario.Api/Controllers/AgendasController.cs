using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PortalUsuario.Core.Interfaces;
using PortalUsuario.Core.Services;
using PortalUsuario.Shared.DTO;


namespace PortalUsuario.Api.Controllers;

[Route("api/v1/")]
[Authorize]
public class AgendasController : ControllerBase
{
    private readonly IAgendaServices _services;


    public AgendasController(IAgendaServices services)
    {
        _services = services;
    }

    [HttpGet("agenda")]
    public async Task<IActionResult> BuscarAngenda(ParametrosAgendaDTO dto)
    {
        try
        {
            var dadosAgenda = await _services.BuscarDados(dto);

            return Ok(dadosAgenda);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    [HttpGet]
    [Route("eventos")]
    public async Task<IActionResult> BuscarEventos(DateTime data)
    {
        try
        {
            var response = await _services.BuscarEventoDoDia(data);
            return Ok(response);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    [HttpGet("clientes")]
    public async Task BuscarClientess()
    {
        throw new NotImplementedException();
    }


    [HttpGet("contratos")]
    public async Task BuscarContratoss()
    {
        throw new NotImplementedException();
    }
}