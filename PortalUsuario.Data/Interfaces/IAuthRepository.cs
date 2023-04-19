using PortalUsuario.Shared.DTO;
using PortalUsuario.Shared.Models;

namespace PortalUsuario.Data.Interfaces;

public interface IAuthRepository
{
    Task<UsuarioModel> GetUserData(LoginDto login);
    Task AtualizarCookies(string cookies);

}