using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PortalUsuario.Core.Interfaces;
using PortalUsuario.Core.Services;
using PortalUsuario.Shared.DTO;

namespace PortalUsuario.Api.Controllers;

[Route("api/v1/avisos")]
[Authorize]
public class AvisosController : ControllerBase
{
    private readonly IAvisosServices _services;


    public AvisosController(IAvisosServices services)
    {
        _services = services;
    }

    [HttpGet]
    public async Task<IActionResult> BuscarAvisos(bool isAdm)
    {
        var avisos = await _services.BuscarAvisos(isAdm);

        return Ok(avisos);
    }

    [HttpGet("{nSeq:int}")]
    public async Task<IActionResult> BuscarAvisosPorId(int nSeq)
    {
        var aviso = await _services.BuscarAvisoPorId(nSeq);
        return Ok(aviso);
    }

    [HttpGet("{nSeq:int}/arquivos")]
    public async Task<IActionResult> BuscarArquivosPorNSeq(int nSeq)
    {
        var aviso = await _services.BuscarArquivos(nSeq);
        return Ok(aviso);
    }

    [HttpPost]
    public async Task<IActionResult> CriarAviso(AvisoDto dto)
    {
        await _services.CadastrarAviso(dto);

         

        return Ok();
    }
}