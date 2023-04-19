using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PortalUsuario.Core.Interfaces;

namespace PortalUsuario.Api.Controllers;

[ApiController]
[Route("api/v1/modulos")]
[Authorize]
public class ModulosController : ControllerBase
{
    private readonly IModulosServices _service;
    private readonly ILogger<ModulosController> _logger;

    public ModulosController(IModulosServices services, ILogger<ModulosController> logger)
    {
        _service = services;
        _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var sistemas = await _service.BuscarModulos();
            return Ok(sistemas);
        }
        catch (Exception e)
        {
            _logger.LogError("Ocorreu um erro ao tentar buscar os modulos");
            Console.WriteLine(e);
            throw;
        }
    }
}