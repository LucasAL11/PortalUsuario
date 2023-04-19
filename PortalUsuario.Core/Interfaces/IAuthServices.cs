using PortalUsuario.Shared.DTO;

namespace PortalUsuario.Core.Interfaces;

public interface IAuthServices
{
    Task<UserDataDto> BuscarDadosUsuario(LoginDto login);

    Task AtualizarCookies(string cookies);
}