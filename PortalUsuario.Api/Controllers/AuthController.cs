using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PortalUsuario.Core.Interfaces;
using PortalUsuario.Shared.DTO;

namespace PortalUsuario.Api.Controllers;

[Route("api/v1/auth")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthServices _services;
    private readonly ILogger<AuthController> _logger;

    public AuthController(IAuthServices services, ILogger<AuthController> logger)
    {
        _services = services;
        _logger = logger;
    }

    [HttpPost("login")]
    [AllowAnonymous]
    public async Task<IActionResult> Login([FromBody] LoginDto login)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            var user = await _services.BuscarDadosUsuario(login);

            return Ok(user);
        }
        catch (ArgumentException e)
        {
            _logger.LogError(e, "Erro ocorreu durante o login");
            return BadRequest(e.Message);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Erro inesperado ocorreu durante o login");
            return BadRequest("Ocorreu um erro inesperado");
        }
    }

    [HttpPost]
    public async Task<IActionResult> UpdateCookies(string cookies)
    {
        try
        {
            await _services.AtualizarCookies(cookies);
            return Ok("Cookies Atualizados com sucesso");
        }
        catch (ArgumentException e)
        {
            _logger.LogError(e, "Erro ocorreu durante o atualizar cookies");
            return BadRequest(e.Message);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Erro inesperado ocorreu durante ao atualizar cookies");
            return BadRequest("Ocorreu um erro inesperado");
        }
    }
}