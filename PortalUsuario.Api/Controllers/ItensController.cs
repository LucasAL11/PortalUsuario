using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PortalUsuario.Core.Interfaces;
using PortalUsuario.Core.Services;
using PortalUsuario.Shared.DTO;


namespace PortalUsuario.Api.Controllers;

[Route("api/v1/rat-itens/{idRat:int}")]
[ApiController]
[Authorize]
public class RatItensController : Controller
{
    private readonly IItenRatServices _services;

    public RatItensController(IItenRatServices services)
    {
        _services = services;
    }

    [HttpGet]
    public async Task<IActionResult> Get(int idRat)
    {
        try
        {
            var response = await _services.BuscarItensRat(idRat);
            return Ok(response);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    [HttpGet("{sequencial:int}")]
    public async Task<IActionResult> BuscarItemUnicoRat(int idRat, int sequencial)
    {
        try
        {
            var response = await _services.BucarItemRatUnico(idRat, sequencial);
            return Ok(response);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }


    [HttpPut("{sequencial}")]
    public async Task<IActionResult> EditarItemRat(int idRat, RatItensDto dto)
    {
        try
        {
            await _services.EditarItemRat(dto);
            return Ok();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest(e.Message);
        }
        
    }

    [HttpPost("{sequencial}")]
    public async Task<IActionResult> AtualizarHorasRat(int idRat,[FromQuery] decimal horas)
    {
        var atualizado = await _services.AtualizarHorarioItemRat(idRat, horas);

        if (atualizado)
            return Ok();

        return BadRequest();
    }

    [HttpPost]
    public async Task<IActionResult> Post(RatItensDto model)
    {
        await _services.AdicionarItem(model);
        return Ok();
    }

    [HttpPatch("{sequencial:int}")]
    public async Task<IActionResult> Delete(int idRat, int sequencial)
    {
        var removido = await _services.RemoverItemRat(idRat, sequencial);

        if (removido)
            return Ok("Removido com sucesso");

        return BadRequest();
    }
}