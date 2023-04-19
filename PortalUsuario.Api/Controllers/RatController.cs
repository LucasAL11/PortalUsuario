using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PortalUsuario.Core.Interfaces;
using PortalUsuario.Shared.DTO;
using PortalUsuario.Shared.Models;

namespace PortalUsuario.Api.Controllers;

[Route("api/v1/rat")]
[ApiController]
[Authorize]
public class RatController : Controller
{
    private readonly IRatService _service;

    public RatController(IRatService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> BuscarRats(ParametrosRatDTO dto)
    {
        try
        {
            var response = await _service.BuscarRats(dto);
            return Ok(response);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest(e.Message);
        }
    }
    
    [HttpGet]
    [Route("/BuscarCamposDesabilitados")]
    public async Task<IActionResult> BuscarCamposDesabilitados(int idRat, string CodUsuario)
    {
        var response = await _service.BuscarCamposDesabilitados(idRat, CodUsuario);
        return Ok(response);
    }
    
    [HttpPost]
    public async Task<IActionResult> Post(RatModel rat)
    {
        try
        {
            await _service.CriarRat(rat);
            return Ok("Rat criado com sucesso");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    [HttpPut("{idRat:int}")]
    public async Task<IActionResult> AtualizarRat(RatModel model, int idRat)
    {
        try
        {
            await _service.AtualizarRat(model);
            return Ok();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    [HttpPatch("{idRat:int}")]
    public async Task<IActionResult> FinalizarRat(int idRat, decimal horasRecebidas)
    {
        await _service.FinalizarRat(idRat);
        return Ok();
    }
}