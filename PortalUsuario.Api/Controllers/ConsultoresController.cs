using Microsoft.AspNetCore.Mvc;
using PortalUsuario.Core.Interfaces;

namespace PortalUsuario.Api.Controllers;

[Route("api/v1/consultores")]
public class ConsultoresController : ControllerBase
{
    private readonly IConsultoresServices _services;
    private readonly ILogger<ConsultoresController> _logger;

    public ConsultoresController(IConsultoresServices services, ILogger<ConsultoresController> logger)
    {
        _services = services ?? throw new ArgumentNullException(nameof(services));
        _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> BuscarListaDeConsultores()
    {
        try
        {
            var consultores = await _services.GetAll();
            return Ok(consultores);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Erro ao buscar lista de consultores");
            return BadRequest("Ocorreu um erro ao buscar a lista de consultores. Tente novamente mais tarde.");
        }
    }
}