using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PortalUsuario.Core.Interfaces;
using PortalUsuario.Core.Services;
using PortalUsuario.Shared.DTO;

namespace PortalUsuario.Api.Controllers;

[Route("api/v1/servicos"), ApiController, Authorize]
public class ServicosController : Controller
{
    private readonly IServicosServices _services;
    private readonly ILogger<ServicosController> _logger;

    public ServicosController(IServicosServices services, ILogger<ServicosController> logger)
    {
        _services = services;
        _logger = logger;
    }


    [HttpGet("{codColigada:int}")]
    public async Task<IActionResult> GetAll(int codColigada)
    {
        try
        {
            return Ok(await _services.Buscar(codColigada));
        }
        catch (Exception e)
        {
            _logger.LogError($"não foi possivel buscar serviços, erro: {e}");
            Console.WriteLine(e);
            throw;
        }
        
    }
}