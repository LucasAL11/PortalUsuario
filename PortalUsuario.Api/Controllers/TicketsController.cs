using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PortalUsuario.Core.Interfaces;
using PortalUsuario.Core.Services;

namespace PortalUsuario.Api.Controllers;

[Route("api/v1/Tickets")]
[ApiController]
[Authorize]
public class TicketsController : Controller
{
    private readonly ITicketsServices _services;

    public TicketsController()
    {
        _services = new TicketsServices();
    }

    [HttpGet]
    [Route("{usuario:alpha}")]
    public async Task<IActionResult> BuscarTickets(string usuario)
    {
        if (string.IsNullOrEmpty(usuario))
            return BadRequest("Usuario invalido");

        var response = await _services.BuscarQuantidadeDeTicket(usuario);

        return Ok(response);
    }

    [HttpGet]
    [Route("{usuario}/resolvidos")]
    public async Task<IActionResult> BuscarTicketsResolvidos(string usuario)
    {
        if (string.IsNullOrEmpty(usuario))
            return BadRequest("Usuario invalido");

        var response = await _services.BuscarQuantidadeTicketsResolvidos(usuario);

        return Ok(response);
    }

    [HttpGet]
    [Route("{usuario}/abertos")]
    public async Task<IActionResult> BuscarTicketsAbertos(string usuario)
    {
        if (string.IsNullOrEmpty(usuario))
            return BadRequest("Usuario invalido");

        var response = await _services.BuscarQuantidadeDeTicketAbertos(usuario);

        return Ok(response);
    }
}