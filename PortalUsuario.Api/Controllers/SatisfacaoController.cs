using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PortalUsuario.Core.Interfaces;
using PortalUsuario.Core.Services;
using PortalUsuario.Shared.DTO;


namespace PortalUsuario.Api.Controllers;

[Route("api/v1/satisfacao"), ApiController, Authorize]
public class SatisfacaoController : Controller
{
    private readonly IPesquisaDeSatisfacaoService _service;

    public SatisfacaoController(IConfiguration configuration)
    {
        _service = new PesquisaDeSatisfacaoService(ApiUtils.GetConnectionString(configuration));
    }
    
    [HttpPost]
    public async Task<IActionResult> EnviarPesquisaDeSatisfacao(PesquisaSatisfacaoDTO dto)
    {
        await _service.EnviarPesquisaDeSatisfacao(dto);
        return Ok();
    }
    
    
    [HttpPatch]
    [Route("reiniciar")]
    public async Task<IActionResult> ReiniciarPesquisa()
    {
        await _service.ReiniciarPesquisa();
        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var response = await _service.BuscarListaDePesquisaDeSatisfacao();
        return Ok(response);
    }
    
    [HttpGet]
    [Route("{codUsuario}")]
    public async Task<IActionResult> Get(string CodUsuario)
    {
        var response = await _service.BuscarPesquisaDeSatisfacao(CodUsuario);
        return Ok(response);
    }
    
    [HttpGet]
    [Route("resultado")]
    public async Task<IActionResult> GetResult()
    {
        var response = await _service.BuscarResultadoPesquisaDeSatisfacao();
        return Ok(response);
    }
}